using ApplicationDomain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Requests
{
    public class RestaurantDetailRequest : RequestBase
    {
        public int Id { set; get; }
    }
    public class RestaurantDetailRequestValidator: AbstractValidator<RestaurantDetailRequest>
    {
        public RestaurantDetailRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Id).NotNull();
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
