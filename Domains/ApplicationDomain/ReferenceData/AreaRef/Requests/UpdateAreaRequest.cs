using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Requests
{
    public class UpdateAreaRequest : RequestBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }
        public int? UserId { set; get; }
    }

    public class UpdateAreaRequestValidator : AbstractValidator<CreateAreaRequest>
    {
        public UpdateAreaRequestValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
        }
    }

    public class UpdateAreaRequestMapper : Profile
    {
        public UpdateAreaRequestMapper()
        {
            CreateMap<UpdateAreaRequest, Area>();
        }
    }
}
