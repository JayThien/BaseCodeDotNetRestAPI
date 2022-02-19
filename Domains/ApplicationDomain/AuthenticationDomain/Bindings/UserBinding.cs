using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Bindings
{
    public class UserBinding
    {
        public int Id { set; get; }
        public string Fullname { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime DateOfBirth { set; get; }
        public UserStatus Status { set; get; }
        public bool Gender { set; get; }
        public string AvatarURL { set; get; }
        public int RoleId { set; get; }
        public string RoleName { set; get; }
        public int Point { set; get; }
    }

    public class UserBindingMapper : Profile
    {
        public UserBindingMapper()
        {
            CreateMap<UserBinding, UserBinding>();
            CreateMap<User, UserBinding>();
        }
    }
}
