using ApplicationDomain.Entities;
using ApplicationDomain.PromotionDomain.Requests;
using AspNetCore.UnitOfWork;
using System.Linq;

namespace ApplicationDomain.IRepositories
{
    public interface IPromotionRepository : IGenericRepository<Promotion, int>
    {
        IQueryable List(ListPromotionRequest requestData);
    }
}
