using System.Threading.Tasks;

namespace ApplicationDomain.IServices
{
    public interface IUserPromotionService
    {
        Task CreateAsync(int promotionId, int min, int max);
    }
}
