using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.ProductRef.Models;
using AutoMapper;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Requests
{
    public class UpdateProductRequest : RequestBase
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
        public List<Addition> Additions { set; get; }
    }

    public class UpdateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
        }
    }

    public class UpdateProductRequestMapper : Profile
    {
        public UpdateProductRequestMapper()
        {
            CreateMap<UpdateProductRequest, Product>()
                .ForMember(d => d.Additions, opt => opt.MapFrom(s => s.Additions == null ? null : JsonConvert.SerializeObject(s.Additions)));
        }
    }
}
