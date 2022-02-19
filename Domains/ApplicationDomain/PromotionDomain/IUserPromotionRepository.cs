using ApplicationDomain.Entities;
using AspNetCore.UnitOfWork;

namespace ApplicationDomain.IRepositories
{
    public interface IUserPromotionRepository : IGenericRepository<UserPromotion, int>
    {
    }
}
