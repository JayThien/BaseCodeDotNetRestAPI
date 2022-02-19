using ApplicationDomain.Entities;
using AspNetCore.UnitOfWork;

namespace ApplicationDomain.BookingDomain
{
    public interface IBookingRepository : IGenericRepository<Booking, int>
    {
    }
}
