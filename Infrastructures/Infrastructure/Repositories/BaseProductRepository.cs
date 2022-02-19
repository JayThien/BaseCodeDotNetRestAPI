using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.BaseProductRef;
using ApplicationDomain.ReferenceData.BaseProductRef.Requests;

using AspNetCore.UnitOfWork.EntityFramework;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class BaseProductRepository : GenericRepository<BaseProduct, int>, IBaseProductRepository
    {
        private ApplicationDbContext _dbContext;
        public BaseProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable List(ListBaseProductRequest requestData)
        {
            return this.dbSet.Where(p => (requestData.Categories.Count == 0 || requestData.Categories.Contains(p.Category)) &&
            (string.IsNullOrEmpty(requestData.SearchTerm) || p.Name.Contains(requestData.SearchTerm)) &&
            (requestData.SubCategories.Count == 0 || requestData.SubCategories.Contains(p.SubCategory)));
        }

    }
}
