using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Requests
{
    public class DeleteRestaurantRequest : RequestBase
    {
        public int Id { set; get; }
    }

    public class DeleteRestaurantRequestValidator : AbstractValidator<DeleteRestaurantRequest>
    {
        public DeleteRestaurantRequestValidator()
        {
        }
    }

    public class DeleteRestaurantRequestMapper : Profile
    {
        public DeleteRestaurantRequestMapper()
        {
        }
    }
}
