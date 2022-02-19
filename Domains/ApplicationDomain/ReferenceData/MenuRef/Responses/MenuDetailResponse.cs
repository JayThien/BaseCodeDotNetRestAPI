using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Responses
{
    public class MenuDetailResponse : ResponseBase
    {
        public int Id { set; get; }
        public string AreaName { set; get; }
        public int AreaId { set; get; }
        public Country Country { set; get; }
    }

    public class MenuDetailResponseMapper : Profile
    {
        public MenuDetailResponseMapper()
        {
            CreateMap<Menu, MenuDetailResponse>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Area.Country));
        }
    }
}
