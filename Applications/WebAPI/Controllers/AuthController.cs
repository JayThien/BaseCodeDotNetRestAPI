using ApplicationDomain.AuthenticationDomain;
using ApplicationDomain.AuthenticationDomain.Requests;
using AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    { 
        private readonly IAuthService authService;
        private readonly IOptions<IdentityOptions> identityOptions;

        public AuthController( 
            IAuthService authService,
            IOptions<IdentityOptions> identityOptions
            )
        { 
            this.authService = authService;
            this.identityOptions = identityOptions;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok("Ok:");
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await this.authService.LoginAsync(request);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            if (result.IsLockedOut)
            {
                return BadRequest($"User account locked out, max failed access attemps are {identityOptions.Value.Lockout.MaxFailedAccessAttempts}");
            }
            else if (result.IsNotAllowed)
            {
                return BadRequest("User account is not allowed, make sure your account have been verified");
            }
            else if (result.RequiresTwoFactor)
            {
                return BadRequest("Two Factor Login is required");
            }

            return BadRequest("User Name or Password does not match");

        }

        ////[Route("change-password")]
        ////[HttpPut]
        ////public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRq changePasswordRq)
        ////{
        ////    return Ok(await this.authService.ChangePassword(this.GetCurrentUserId(), changePasswordRq));
        ////}
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            return await this.authService.RegisterAsync(request);
            
        }

        //[Route("confirm")]
        //[HttpPost]
        //public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        //{
        //    await this.authService.ConfirmEmail(request);
        //    return Ok();
        //}
    }
}
