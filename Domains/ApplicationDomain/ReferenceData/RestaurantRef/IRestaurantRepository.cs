using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.RestaurantRef.Requests;
using AspNetCore.UnitOfWork;
using System.Linq;

namespace ApplicationDomain.ReferenceData.RestaurantRef
{
    public interface IRestaurantRepository : IGenericRepository<Restaurant, int>
    {
        IQueryable List(ListRestaurantRequest request);
    }
}
