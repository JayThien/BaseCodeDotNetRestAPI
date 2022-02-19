using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BookingDomain.Requests
{
    public class BookingRequest : RequestBase
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateTime { set; get; }
        public int Size { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Message { set; get; }
        public EventType EventType { set; get; }
        //
        public int RestaurantId { set; get; }
    }

    public class BookingRequestMapper : Profile
    {
        public BookingRequestMapper()
        {
            CreateMap<BookingRequest, Booking>();
        }
    }
}
