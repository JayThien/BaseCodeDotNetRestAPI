using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using ApplicationDomain.PromotionDomain.Requests;
using AspNetCore.UnitOfWork.EntityFramework;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion, int>, IPromotionRepository
    {
        public PromotionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable List(ListPromotionRequest request)
        {
            return this.dbSet.Where(p =>
            (string.IsNullOrEmpty(request.SearchTerm) || p.Description.Contains(request.SearchTerm))
            && (string.IsNullOrEmpty(request.Code) || p.Code.Contains(request.Code)));
        }
    }
}
