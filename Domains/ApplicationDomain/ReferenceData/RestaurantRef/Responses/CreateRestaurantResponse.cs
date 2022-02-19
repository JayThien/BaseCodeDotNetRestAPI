using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Responses
{
    public class CreateRestaurantResponse : ResponseBase
    {
        public int Id { set; get; }
    }

    public class CreateRestaurantResponseMapper : Profile
    {
        public CreateRestaurantResponseMapper()
        {
            CreateMap<Restaurant, CreateRestaurantResponse>();
        }
    }
}
