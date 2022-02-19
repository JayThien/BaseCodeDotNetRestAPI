using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Responses
{
    public class AreaDetailResponse : ResponseBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }
        public int UserId { set; get; }
    }

    public class AreaDetailResponseMapper : Profile
    {
        public AreaDetailResponseMapper()
        {
            CreateMap<Area, AreaDetailResponse>();
        }
    }
}
