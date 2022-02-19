using ApplicationDomain.AuthenticationDomain.Requests;
using ApplicationDomain.AuthenticationDomain.Responses;
using ApplicationDomain.Entities;
using AspNetCore.Common.Identity;
using AspNetCore.EmailSender;
using AspNetCore.Mvc.JwtBearer;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationDomain.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationDomain.AuthenticationDomain
{
    public class AuthService : ServiceBase, IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IEmailSender _emailSender;
        public AuthService(
            IMapper mapper,
            IUnitOfWork uow,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IJwtTokenService jwtTokenService,
            IEmailSender emailSender
            ) : base(mapper, uow)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Message = "User haven't registered in system"
                };
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, request.LockoutOnFailure ?? false);
            LoginResponse response = new LoginResponse();
            this._mapper.Map(signInResult, response);

            if (!signInResult.Succeeded)
            {
                return response;
            }
            response.Token = await this.GenerateToken(user);
            return response;
        }
        private async Task<string> GenerateToken(User user)
        {
            // generate token
            var roles = await _userManager.GetRolesAsync(user);
            var userIdentity = new UserIdentity<int>
            {
                Id = user.Id,
                UserName = user.UserName,
            };
            List<Claim> customClaims = new List<Claim>();
            customClaims.Add(new Claim("avatarURL", user.AvatarURL == null ? "" : $"{user.AvatarURL}"));
            var restaurantClaim = await this._userManager.GetClaimsAsync(user);
            customClaims.Add(restaurantClaim.FirstOrDefault());
            // grant permission
            //Permission permission = new Permission(roles.FirstOrDefault());

            //foreach (PropertyInfo propertyInfo in permission.GetType().GetProperties())
            //{
            //    customClaims.Add(new Claim("permissions", JsonConvert.SerializeObject(new PermissionClaim()
            //    {
            //        type = propertyInfo.Name,
            //        value = propertyInfo.GetValue(permission).ToString()
            //    })));
            //}
            return _jwtTokenService.GenerateLoginToken<int>(userIdentity, roles, customClaims);
        }
        //public async Task<LoginResponse> LoadProfile(User user)
        //{
        //    LoginResponse response = new LoginResponse();
        //    response.IsNeedToChangePassword = user.Status == Common.UserStatus.DEACTIVATE;
        //    // generate token
        //    var roles = await _userManager.GetRolesAsync(user);
        //    var userIdentity = new UserIdentity<int>
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName,
        //    };
        //    List<Claim> customClaims = new List<Claim>();
        //    customClaims.Add(new Claim("avatarURL", user.AvatarURL == null ? "" : $"{user.AvatarURL}"));
        //    var restaurantClaim = await this._userManager.GetClaimsAsync(user);
        //    customClaims.Add(restaurantClaim.FirstOrDefault());
        //    // grant permission
        //    Permission permission = new Permission(roles.FirstOrDefault());

        //    foreach (PropertyInfo propertyInfo in permission.GetType().GetProperties())
        //    {
        //        customClaims.Add(new Claim("permissions", JsonConvert.SerializeObject(new PermissionClaim()
        //        {
        //            type = propertyInfo.Name,
        //            value = propertyInfo.GetValue(permission).ToString()
        //        })));
        //    }
        //    response.Token = _jwtTokenService.GenerateLoginToken<int>(userIdentity, roles, customClaims);
        //    return response;
        //}

        //public async Task<bool> ChangePassword(int userId, ChangePasswordRq rq)
        //{
        //    var user = await _userManager.FindByIdAsync(userId.ToString());

        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    var changePasswordResult = await this._userManager.ChangePasswordAsync(user, rq.CurrentPassword, rq.NewPassword);
        //    if (changePasswordResult.Succeeded)
        //    {
        //        user.TempPassword = null;
        //        await this._userManager.UpdateAsync(user);
        //        await this._uow.SaveChangesAsync();
        //        return true;
        //    }
        //    return false;
        //}

        public async Task<JsonResult> RegisterAsync(RegisterRequest request)
        {
            var user = this._mapper.Map<User>(request);
            var result = await this._userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string emailTemplate = System.IO.File.ReadAllText($@"{Directory.GetCurrentDirectory()}\\bin\\Debug\net5.0\\EmailTemplate\\Register.html");

            emailTemplate = emailTemplate.Replace("{{email}}", request.Email);
            emailTemplate = emailTemplate.Replace("{{verifyToken}}", token);
            await this._emailSender.SendEmailAsync(request.Email, "Please verify your account", emailTemplate, true);
            return JsonUtil.Success(result);
        }

        public async Task ConfirmEmail(ConfirmEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("");
            }
            var result = await _userManager.ConfirmEmailAsync(user, request.Token);
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
        }


    }
}
