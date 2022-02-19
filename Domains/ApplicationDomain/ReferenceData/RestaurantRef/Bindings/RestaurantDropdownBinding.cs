using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Bindings
{
    public class RestaurantDropdownBinding : Dropdown
    {
        public int CountryId { set; get; }
    }
    public class RestaurantDropdownMapper : Profile
    {
        public RestaurantDropdownMapper()
        {
            CreateMap<Restaurant, RestaurantDropdownBinding>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Name));
        }
    }

}
