using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Bindings
{
    public class AreaDropdownBinding : Dropdown
    {
        public Country Country { set; get; }
    }

    public class AreaDropdownBindingMapper : Profile
    {
        public AreaDropdownBindingMapper()
        {
            CreateMap<Area, AreaDropdownBinding>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Name));

        }
    }
}
