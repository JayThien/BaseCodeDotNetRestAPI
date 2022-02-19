using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Responses
{
    public class CreateProductResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class CreateProductReponseMapper : Profile
    {
        public CreateProductReponseMapper()
        {
            CreateMap<Product, CreateProductResponse>();
        }
    }
}
