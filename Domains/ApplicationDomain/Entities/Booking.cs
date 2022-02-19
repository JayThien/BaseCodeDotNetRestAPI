using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Booking : EntityBase<int>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateTime { set; get; }
        public int Size { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Message { set; get; }
        public EventType EventType { set; get; }
        //
        public BookingStatus Status { set; get; }
        public int RestaurantId { set; get; }
        public Restaurant Restaurant { set; get; }
    }
}
