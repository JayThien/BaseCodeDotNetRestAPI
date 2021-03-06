using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Requests
{
    public class CreateMenuRequest : RequestBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }
        public int? UserId { set; get; }
    }

    public class CreateMenuRequestValidator : AbstractValidator<CreateMenuRequest>
    {
        public CreateMenuRequestValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
        }
    }

    public class CreateMenuRequestMapper : Profile
    {
        public CreateMenuRequestMapper()
        {
            CreateMap<CreateMenuRequest, Menu>();
        }
    }
}
