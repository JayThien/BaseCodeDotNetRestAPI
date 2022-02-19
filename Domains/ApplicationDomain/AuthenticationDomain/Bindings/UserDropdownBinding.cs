using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Bindings
{
    public class UserDropdownBinding : Dropdown
    {
        public string AvatarURL { set; get; }
    }

    public class UserDropdownBindingMapper : Profile
    {
        public UserDropdownBindingMapper()
        {
            CreateMap<User, UserDropdownBinding>()
               .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
               .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Fullname));
        }
    }
}
