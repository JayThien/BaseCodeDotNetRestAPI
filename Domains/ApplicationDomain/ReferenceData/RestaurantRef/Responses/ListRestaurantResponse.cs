using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.RestaurantRef.Bindings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Responses
{
    public class ListRestaurantResponse : PaginationResponse<RestaurantBinding>
    {
    }

    public class ListRestaurantResponseMapper : Profile
    {
        public ListRestaurantResponseMapper()
        {
            CreateMap<Restaurant, RestaurantBinding>();
        }
    }
}
