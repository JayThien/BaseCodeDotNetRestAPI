using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Requests
{
    public class ListRestaurantRequest : PaginationRequest
    {
        public List<Country> CountryCodes { set; get; }
    }

    public class ListRestaurantRequestValidator : AbstractValidator<ListRestaurantRequest>
    {
        public ListRestaurantRequestValidator()
        {
        }
    }

    public class ListRestaurantRequestMapper : Profile
    {
        public ListRestaurantRequestMapper()
        {
        }
    }
}
