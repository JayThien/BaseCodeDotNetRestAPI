using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;

namespace Infrastructure.Repositories
{
    public class UserPromotionRepository : GenericRepository<UserPromotion, int>, IUserPromotionRepository
    {
        public UserPromotionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
