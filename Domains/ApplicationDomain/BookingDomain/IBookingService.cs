using ApplicationDomain.BookingDomain.Requests;
using System.Threading.Tasks;

namespace ApplicationDomain.BookingDomain
{
    public interface IBookingService
    {
        Task Book(BookingRequest requestData);
    }
}
