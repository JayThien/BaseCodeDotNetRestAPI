using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.PromotionDomain.Responses
{
    public class CreatePromotionResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class CreatePromotionResponseMapper : Profile
    {
        public CreatePromotionResponseMapper()
        {
            CreateMap<Promotion, CreatePromotionResponse>();
        }
    }
}
