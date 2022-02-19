using ApplicationDomain.Entities;
using AspNetCore.UnitOfWork;

namespace ApplicationDomain.IRepositories
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct, int>
    {
    }
}
