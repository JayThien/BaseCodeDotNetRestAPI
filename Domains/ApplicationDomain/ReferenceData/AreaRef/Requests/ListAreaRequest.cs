using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.AreaRef.Requests
{
    public class ListAreaRequest : PaginationRequest
    {
        public Country? Country { set; get; }
    }

    public class ListAreaRequestValidator : AbstractValidator<ListAreaRequest>
    {
        public ListAreaRequestValidator()
        {
        }
    }

    public class ListAreaRequestMapper : Profile
    {
        public ListAreaRequestMapper()
        {
        }
    }
}
