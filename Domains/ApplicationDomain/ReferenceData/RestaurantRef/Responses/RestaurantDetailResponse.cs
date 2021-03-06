using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Responses
{
    public class RestaurantDetailResponse : ResponseBase
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string OpenTime { set; get; }
        public string CloseTime { set; get; }
        public string ReservationLink { set; get; }
        public string ImageUrl { set; get; }
        public string LocationImage { set; get; }
        //
        public Country Country { set; get; }
    }

    public class RestaurantDetailResponseMapper : Profile
    {
        public RestaurantDetailResponseMapper()
        {
            CreateMap<Restaurant, RestaurantDetailResponse>();
        }
    }
}
