using ApplicationDomain.Entities;
using AspNetCore.UnitOfWork;

namespace ApplicationDomain.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
    }
}
