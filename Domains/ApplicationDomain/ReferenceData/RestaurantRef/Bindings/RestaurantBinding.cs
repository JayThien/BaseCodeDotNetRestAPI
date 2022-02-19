using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.Entities;

namespace ApplicationDomain.ReferenceData.RestaurantRef.Bindings
{
    public class RestaurantBinding
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
        public UserBinding User { set; get; }
    }
}
