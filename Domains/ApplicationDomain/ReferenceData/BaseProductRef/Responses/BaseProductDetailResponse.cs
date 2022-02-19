using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Responses
{
    public class BaseProductDetailResponse : ResponseBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public bool IsAvailable { set; get; }
        public SubCategory SubCategory { set; get; }
        public Category Category { set; get; }
    }

    public class BaseProductDetailResponseMapper : Profile
    {
        public BaseProductDetailResponseMapper()
        {
            CreateMap<BaseProduct, BaseProductDetailResponse>();
        }
    }
}
