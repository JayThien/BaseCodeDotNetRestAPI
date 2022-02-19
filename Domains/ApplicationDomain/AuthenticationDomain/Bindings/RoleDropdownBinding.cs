using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.AuthenticationDomain.Bindings
{
    public class RoleDropdownBinding: Dropdown
    {
    }

    public class RoleDropdownBindingMapper : Profile
    {
        public RoleDropdownBindingMapper()
        {
            CreateMap<Role, RoleDropdownBinding>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Name));

        }
    }
}
