using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class BaseProduct : EntityBase<int>
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public bool IsAvailable { set; get; }
        public Category Category { set; get; }
        public SubCategory SubCategory { set; get; }
    }
    public class BaseProductMapper : Profile
    {
        public BaseProductMapper()
        {
            CreateMap<BaseProduct, Product>();
        }
    }
}
