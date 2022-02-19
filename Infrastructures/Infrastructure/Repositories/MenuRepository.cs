using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.MenuRef;
using ApplicationDomain.ReferenceData.MenuRef.Requests;
using AspNetCore.UnitOfWork.EntityFramework;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MenuRepository : GenericRepository<Menu, int>, IMenuRepository
    {
        private ApplicationDbContext _dbContext;
        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable List(ListMenuRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
