using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Requests
{
    public class CreateRestaurantRequest : RequestBase
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
        public int UserId { set; get; }
        public Country Country { set; get; }
    }

    public class CreateRestaurantRequestValidator : AbstractValidator<CreateRestaurantRequest>
    {
        public CreateRestaurantRequestValidator()
        {
        }
    }

    public class CreateRestaurantRequestMapper : Profile
    {
        public CreateRestaurantRequestMapper()
        {
            CreateMap<CreateRestaurantRequest, Restaurant>()
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => Regex.Replace(s.PhoneNumber, @"[^\d]", "")));
        }
    }
}
