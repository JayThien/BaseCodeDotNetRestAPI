using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.MenuRef.Requests;
using AspNetCore.UnitOfWork;
using System.Linq;

namespace ApplicationDomain.ReferenceData.MenuRef
{
    public interface IMenuRepository : IGenericRepository<Menu, int>
    {
        IQueryable List(ListMenuRequest request);
    }
}
