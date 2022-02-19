using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationDomain.AuthenticationDomain.Requests
{
    public class CreateUserRequest
    {
        public string Fullname { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime DateOfBirth { set; get; }
        public UserStatus Status { set; get; }
        public int RestaurantId { set; get; }
        public bool Gender { set; get; }
        public string AvatarURL { set; get; }
        public int RoleId { set; get; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {

        }
    }

    public class CreateUserRequestMapper : Profile
    {
        public CreateUserRequestMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => Regex.Replace(s.PhoneNumber, @"[^\d]", "")))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => Regex.Replace(s.PhoneNumber, @"[^\d]", "")))
                .ForMember(d => d.SearchName, opt => opt.MapFrom(s => StringUtil.GenerateSearchString(s.Fullname)));
        }
    }
}
