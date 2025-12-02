using AutoMapper;
using Contracts.ILogging;
using Contracts.IServices;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.DataTransferObjects.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _Logger;
        private readonly IMapper _Mapper;
        private readonly UserManager<User> _UserManager;
        private readonly IConfiguration _Configuration;

        private User? _User;

        public AuthenticationService(ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _Logger = logger;
            _Mapper = mapper;
            _UserManager = userManager;
            _Configuration = configuration;
        }

        public async Task<string> CreateToken()
        {

            SigningCredentials SigningCredentials = GetSigningCredentials();

            List<Claim> Claims = await GetClaims();

            JwtSecurityToken TokenOptions = GenerateTokenOptions(SigningCredentials, Claims);

            return new JwtSecurityTokenHandler().WriteToken(TokenOptions);

        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto UserForRegistration)
        {
            User User = _Mapper.Map<User>(UserForRegistration);

            IdentityResult Result = await _UserManager.CreateAsync(User, UserForRegistration.Password!);

            if (Result.Succeeded)
                await _UserManager.AddToRolesAsync(User, UserForRegistration.Roles!);

            return Result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto UserForAuth)
        {
            _User = await _UserManager.FindByNameAsync(UserForAuth.UserName!);

            bool result = (_User != null && await _UserManager.CheckPasswordAsync(_User, UserForAuth.Password!));

            if (!result)
                _Logger.LogWarn($"{nameof(ValidateUser)}: " + $"Authentication failed. Wrong user name or password.");

            return result;
        }

        private SigningCredentials GetSigningCredentials()
        {

            string? SecretKey = _Configuration.GetSection("JwtSettings").GetValue<string>("SECRET");
            byte[] keyBytes = Encoding.UTF8.GetBytes(SecretKey);

            SymmetricSecurityKey secret = new SymmetricSecurityKey(keyBytes);
            
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            List<Claim> Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _User!.UserName!)
            };

            IList<string> Roles = await _UserManager.GetRolesAsync(_User);
            
            foreach (string Role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, Role));
            }
            
            return Claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            IConfiguration jwtSettings = _Configuration.GetSection("JwtSettings");

            JwtSecurityToken tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
