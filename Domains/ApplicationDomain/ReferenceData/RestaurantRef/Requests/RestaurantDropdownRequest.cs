using ApplicationDomain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Requests
{
    public class RestaurantDropdownRequest: RequestBase
    {
    }

    public class RestaurantDropdownRequestValidator: AbstractValidator<RestaurantDropdownRequest>
    {
        public RestaurantDropdownRequestValidator()
        {

        }
    }
}
