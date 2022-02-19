using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.PromotionDomain.Bindings
{
    public class PromotionBinding
    {
        public int Id { set; get; }
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
        public Country Country { set; get; }
        public int AreaId { set; get; }
    }

    public class PromotionBindingMapper : Profile
    {
        public PromotionBindingMapper()
        {
            CreateMap<Promotion, PromotionBinding>()
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Area.Country));
        }
    }
}
