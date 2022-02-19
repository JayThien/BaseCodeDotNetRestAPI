using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.ProductRef.Models;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.OrderDomain.Models
{
    public class OrderProductDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public string ImageUrl { set; get; }
        public bool IsAvailable { set; get; }
        public int Priority { set; get; }
        public int Quantity { set; get; }
        public double TotalPriceOfProduct { set; get; }
        public SubCategory SubCategory { set; get; }
        public int MenuId { set; get; }
        public int OrderId { set; get; }
        public List<Addition> Additions { set; get; }
    }

    public class OrderProductDTOMapper : Profile
    {
        public OrderProductDTOMapper()
        {
            CreateMap<Product, OrderProductDTO>()
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => 0))
                .ForMember(d => d.TotalPriceOfProduct, opt => opt.MapFrom(s => (double)0))
                .ForMember(d => d.Additions, opt => opt.MapFrom(s => s.Additions == null ? new List<Addition>() : JsonConvert.DeserializeObject<List<Addition>>(s.Additions)));

            CreateMap<OrderProductDTO, OrderProduct>()
                 .ForMember(d => d.Additions, opt => opt.MapFrom(s => s.Additions == null ? null : JsonConvert.SerializeObject(s.Additions)))
                 .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
