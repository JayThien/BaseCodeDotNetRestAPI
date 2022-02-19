using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Requests
{
    public class UpdateBaseProductRequest : RequestBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public bool IsAvailable { set; get; }
        public SubCategory SubCategory { set; get; }
        public Category Category { set; get; }
    }

    public class UpdateBaseProductRequestValidator : AbstractValidator<UpdateBaseProductRequest>
    {
        public UpdateBaseProductRequestValidator()
        {
        }
    }

    public class UpdateBaseProductRequestMapper : Profile
    {
        public UpdateBaseProductRequestMapper()
        {
            CreateMap<UpdateBaseProductRequest, BaseProduct>();
        }
    }
}
