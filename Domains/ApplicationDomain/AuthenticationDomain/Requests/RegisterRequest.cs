using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Requests
{
    public class RegisterRequest
    {
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string ConfirmPassword { set; get; }
        public string Password { set; get; }
    }

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.ConfirmPassword).Equal(p => p.Password);
            RuleFor(p => p.PhoneNumber).NotEmpty();
        }
    }

    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email));
        }
    }
}
