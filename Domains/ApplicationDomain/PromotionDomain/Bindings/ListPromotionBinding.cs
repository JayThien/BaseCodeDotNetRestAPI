using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.PromotionDomain.Bindings
{
    public class ListPromotionBinding
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
        public DateTime From { set; get; }
        public DateTime To { set; get; }
    }

    public class ListPromotionBindingMapper : Profile
    {
        public ListPromotionBindingMapper()
        {
            CreateMap<Promotion, ListPromotionBinding>();
        }
    }
}
