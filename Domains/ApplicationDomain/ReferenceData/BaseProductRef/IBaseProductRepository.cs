using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.BaseProductRef.Requests;
using AspNetCore.UnitOfWork;
using System.Linq;

namespace ApplicationDomain.ReferenceData.BaseProductRef
{
    public interface IBaseProductRepository : IGenericRepository<BaseProduct, int>
    {
        IQueryable List(ListBaseProductRequest request);
    }
}
