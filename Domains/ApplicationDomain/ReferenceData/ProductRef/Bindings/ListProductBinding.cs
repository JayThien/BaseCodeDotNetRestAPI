using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Bindings
{
    public class ListProductBinding
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public double Price { set; get; }
        public bool IsAvailable { set; get; }
        public SubCategory SubCategory { set; get; }
        public Category Category { set; get; }
    }

    public class ListProductBindingMapper : Profile
    {
        public ListProductBindingMapper()
        {
            CreateMap<Product, ListProductBinding>();
        }
    }
}
