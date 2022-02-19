using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Requests
{
    public class DeleteProductRequest : RequestBase
    {
        public int Id { set; get; }
    }

    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidator()
        {
        }
    }

    public class DeleteProductRequestMapper : Profile
    {
        public DeleteProductRequestMapper()
        {
        }
    }
}
