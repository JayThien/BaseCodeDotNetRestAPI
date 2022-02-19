using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.MenuRef.Requests
{
    public class ListMenuRequest : PaginationRequest
    {
        public Country? Country { set; get; }
    }

    public class ListMenuRequestValidator : AbstractValidator<ListMenuRequest>
    {
        public ListMenuRequestValidator()
        {
        }
    }

    public class ListMenuRequestMapper : Profile
    {
        public ListMenuRequestMapper()
        {
        }
    }
}
