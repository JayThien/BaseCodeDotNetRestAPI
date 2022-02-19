using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Bindings
{
    public class MenuBinding
    {
        public int Id { set; get; }
        public string AreaName { set; get; }
        public int AreaId { set; get; }
        public Country Country { set; get; }
    }

    public class MenuBindingMapper : Profile
    {
        public MenuBindingMapper()
        {
            CreateMap<Menu, MenuBinding>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Area.Country));
        }
    }
}
