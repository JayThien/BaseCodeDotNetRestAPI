using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.ProductRef.Requests
{
    public class ListProductRequest : PaginationRequest
    {
        public int MenuId { set; get; }
        public Category Category { set; get; }
        public List<SubCategory> SubCategories { set; get; }
    }

    public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
    {
        public ListProductRequestValidator()
        {
        }
    }

    public class ListProductRequestMapper : Profile
    {
        public ListProductRequestMapper()
        {
        }
    }
}
