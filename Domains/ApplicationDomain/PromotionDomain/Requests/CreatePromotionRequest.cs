using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationDomain.PromotionDomain.Requests
{
    public class CreatePromotionRequest : RequestBase
    {
        public string Code { set; get; }
        public string Description { set; get; }
        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public double MaximumDiscount { set; get; }
        public double MinimumOrderPrice { set; get; }
        public double DiscountPrice { set; get; }
        public bool IsPercent { set; get; }
        public int MinPoint { set; get; }
        public int MaxPoint { set; get; }
        public string ImageUrl { set; get; }
        public int AreaId { set; get; }
    }

    public class CreateRestaurantRequestValidator : AbstractValidator<CreatePromotionRequest>
    {
        public CreateRestaurantRequestValidator()
        {
        }
    }

    public class CreatePromotionRequestMapper : Profile
    {
        public CreatePromotionRequestMapper()
        {
            CreateMap<CreatePromotionRequest, Promotion>();
        }
    }
}
