using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;

namespace Infrastructure.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct, int>, IOrderProductRepository
    {
        private ApplicationDbContext _dbContext;
        public OrderProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
