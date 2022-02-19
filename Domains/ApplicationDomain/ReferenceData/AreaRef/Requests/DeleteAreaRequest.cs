using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Requests
{
    public class DeleteAreaRequest : RequestBase
    {
        public int Id { set; get; }
    }

    public class DeleteAreaRequestValidator : AbstractValidator<DeleteAreaRequest>
    {
        public DeleteAreaRequestValidator()
        {
        }
    }

    public class DeleteAreaRequestMapper : Profile
    {
        public DeleteAreaRequestMapper()
        {
        }
    }
}
