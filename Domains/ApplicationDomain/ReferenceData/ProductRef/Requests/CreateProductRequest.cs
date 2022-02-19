using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Requests
{
    public class CreateProductRequest : RequestBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }
        public int? UserId { set; get; }
    }

    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
        }
    }

    public class CreateProductRequestMapper : Profile
    {
        public CreateProductRequestMapper()
        {
            CreateMap<CreateProductRequest, Product>();
        }
    }
}
