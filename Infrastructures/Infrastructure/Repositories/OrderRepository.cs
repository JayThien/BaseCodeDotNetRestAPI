using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;

namespace Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order, int>, IOrderRepository
    {
        private ApplicationDbContext _dbContext;
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

    }
}
