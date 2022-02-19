using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Requests
{
    public class ConfirmEmailRequest
    {
        public string Email { set; get; }
        public string Token { set; get; } 
    }

    public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailRequestValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Token).NotEmpty();
        }
    }
}
