using Contracts.IServices;
using Controllers.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    [Route("Authentication")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _Service;
        public AuthenticationController(IServiceManager service) => _Service = service;
    


        [HttpPost]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            IdentityResult Result = await _Service.AuthenticationService.RegisterUser(userForRegistration);

            if (!Result.Succeeded)
            {
                foreach (IdentityError error in Result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidateNotNullIActionFilter))]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _Service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            return Ok(new
            {
                Token = await _Service.AuthenticationService.CreateToken()
            });
        }
    }
}
