using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.AreaRef.Requests;
using AspNetCore.UnitOfWork;
using System.Linq;

namespace ApplicationDomain.ReferenceData.AreaRef
{
    public interface IAreaRepository : IGenericRepository<Area, int>
    {
        IQueryable List(ListAreaRequest request);
    }
}
