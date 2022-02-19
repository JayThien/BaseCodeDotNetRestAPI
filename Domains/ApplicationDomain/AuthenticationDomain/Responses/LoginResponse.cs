using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Responses
{
    public class LoginResponse
    {
        public string Token { set; get; }
        public bool Succeeded { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsNotAllowed { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public string Message { set; get; }
    }

    public class LoginResponseMapper: Profile
    {
        public LoginResponseMapper()
        {
            CreateMap<SignInResult, LoginResponse>();
        }
    }
}
