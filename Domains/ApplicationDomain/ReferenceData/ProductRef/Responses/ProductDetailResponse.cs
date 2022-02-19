using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.MenuRef.Bindings;
using ApplicationDomain.ReferenceData.ProductRef.Models;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Responses
{
    public class ProductDetailResponse : ResponseBase
    {

        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public string ImageUrl { set; get; }
        public string Currency { set; get; }
        public bool IsAvailable { set; get; }
        public int Priority { set; get; }
        public SubCategory SubCategory { set; get; }
        public Category Category { set; get; }
        public int MenuId { set; get; }
        public List<Addition> Additions { set; get; }
        public MenuBinding Menu { set; get; }
    }

    public class ProductDetailResponseMapper : Profile
    {
        public ProductDetailResponseMapper()
        {
            CreateMap<Product, ProductDetailResponse>()
                .ForMember(d => d.Additions, opt => opt.MapFrom(s => string.IsNullOrEmpty(s.Additions) ? new List<Addition>() : JsonConvert.DeserializeObject<List<Addition>>(s.Additions)));
        }
    }
}
