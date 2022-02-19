using ApplicationDomain.AuthenticationDomain.Requests;
using ApplicationDomain.AuthenticationDomain.Responses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationDomain.AuthenticationDomain
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request); 
        Task<JsonResult> RegisterAsync(RegisterRequest request);
        Task ConfirmEmail(ConfirmEmailRequest request);
    }
}
