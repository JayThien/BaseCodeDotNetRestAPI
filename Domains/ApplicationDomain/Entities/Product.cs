using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Product : EntityBase<int>
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public string ImageUrl { set; get; }
        public string Additions { set; get; }
        public bool IsAvailable { set; get; }
        public int Priority { set; get; }
        public double PromotedPrice { set; get; }
        public DateTime PromotedFrom { set; get; }
        public DateTime PromotedTo { set; get; }
        //
        public int MenuId { set; get; }
        public Menu Menu { set; get; }
        public Category Category { set; get; }
        public SubCategory SubCategory { set; get; }
    }

    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, Product>();
        }
    }
}
