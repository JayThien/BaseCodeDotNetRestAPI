using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Requests
{
    public class ListBaseProductRequest : PaginationRequest
    {
        public List<Category> Categories { set; get; }
        public List<SubCategory> SubCategories { set; get; }
    }

    public class ListBaseProductRequestValidator : AbstractValidator<ListBaseProductRequest>
    {
        public ListBaseProductRequestValidator()
        {
        }
    }

    public class ListBaseProductRequestMapper : Profile
    {
        public ListBaseProductRequestMapper()
        {
        }
    }
}
