using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Requests
{
    public class DeleteBaseProductRequest : RequestBase
    {
        public int Id { set; get; }
    }

    public class DeleteBaseProductRequestValidator : AbstractValidator<DeleteBaseProductRequest>
    {
        public DeleteBaseProductRequestValidator()
        {
        }
    }

    public class DeleteBaseProductRequestMapper : Profile
    {
        public DeleteBaseProductRequestMapper()
        {
        }
    }
}
