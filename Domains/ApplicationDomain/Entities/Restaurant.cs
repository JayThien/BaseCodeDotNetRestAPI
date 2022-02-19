using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Entities
{
    public class Restaurant: EntityBase<int>
    {
        public string Name { set; get; }
        public string Address { set; get; }
        public double Longitude { set; get; }
        public double Latitude { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string OpenTime { set; get; }
        public string CloseTime { set; get; }
        public string ReservationLink { set; get; }
        public string ImageUrl { set; get; }
        public bool IsOpening { set; get; }
        public string LocationImage { set; get; }
        //
        public Country Country { set; get; }

        public int? UserId { set; get; }
        public User User { set; get; }
    }
}
