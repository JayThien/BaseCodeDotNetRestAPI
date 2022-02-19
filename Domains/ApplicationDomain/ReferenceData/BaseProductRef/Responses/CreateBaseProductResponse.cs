using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Responses
{
    public class CreateBaseProductResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class CreateBaseProductResponseMapper : Profile
    {
        public CreateBaseProductResponseMapper()
        {
            CreateMap<BaseProduct, CreateBaseProductResponse>();
        }
    }
}
