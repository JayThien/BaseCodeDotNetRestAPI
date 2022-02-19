using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.RestaurantRef;
using ApplicationDomain.ReferenceData.RestaurantRef.Requests;
using AspNetCore.UnitOfWork.EntityFramework;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RestaurantRepository : GenericRepository<Restaurant, int>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable List(ListRestaurantRequest request)
        {
            return this.dbSet.Where(p =>
            (string.IsNullOrEmpty(request.SearchTerm) || p.Name.Contains(request.SearchTerm) || p.PhoneNumber.Contains(request.SearchTerm) || p.Email.Contains(request.SearchTerm))
            && (request.CountryCodes.Count == 0 || request.CountryCodes.Contains(p.Country)));
        }
    }
}
