using ApplicationDomain.PromotionDomain.Requests;
using ApplicationDomain.PromotionDomain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.IServices
{
    public interface IPromotionService
    {
        Task<ListPromotionResponse> ListAsync(ListPromotionRequest request);
        Task<CreatePromotionResponse> CreateAsync(CreatePromotionRequest request);
        Task<PromotionDetailResponse> GetAsync(int id);
    }
}
