using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects.User;

namespace Contracts.IServices
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto UserForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
