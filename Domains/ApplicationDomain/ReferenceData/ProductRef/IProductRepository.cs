using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.ProductRef.Requests; 
using AspNetCore.UnitOfWork;
using System.Linq;

namespace ApplicationDomain.ReferenceData.ProductRef
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        IQueryable List(ListProductRequest request);
    }
}
