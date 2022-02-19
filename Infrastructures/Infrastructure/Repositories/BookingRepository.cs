using ApplicationDomain.BookingDomain;
using ApplicationDomain.Entities;
using AspNetCore.UnitOfWork.EntityFramework;

namespace Infrastructure.Repositories
{
    public class BookingRepository : GenericRepository<Booking, int>, IBookingRepository
    {
        private ApplicationDbContext _dbContext;
        public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
