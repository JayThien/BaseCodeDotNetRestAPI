using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Requests
{
    public class LoginRequest
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool? LockoutOnFailure { set; get; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(p => p.UserName).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
