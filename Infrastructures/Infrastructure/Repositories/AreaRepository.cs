using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using ApplicationDomain.ReferenceData.AreaRef;
using ApplicationDomain.ReferenceData.AreaRef.Requests;
using AspNetCore.UnitOfWork.EntityFramework;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AreaRepository : GenericRepository<Area, int>, IAreaRepository
    {
        private ApplicationDbContext _dbContext;
        public AreaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable List(ListAreaRequest request)
        {
            return this.dbSet.Where(p =>
            (string.IsNullOrEmpty(request.SearchTerm) || p.Name.Contains(request.SearchTerm))
            && (request.Country == null || p.Country == request.Country));
        }
    }
}
