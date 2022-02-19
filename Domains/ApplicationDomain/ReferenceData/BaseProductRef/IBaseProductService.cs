using ApplicationDomain.ReferenceData.BaseProductRef.Requests;
using ApplicationDomain.ReferenceData.BaseProductRef.Responses;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.BaseProductRef
{
    public interface IBaseProductService
    {
        Task<ListBaseProductResponse> ListAsync(ListBaseProductRequest request);
        Task<CreateBaseProductResponse> CreateAsync(CreateBaseProductRequest request);
        Task<BaseProductDetailResponse> GetByIdAsync(int id);
        Task<UpdateBaseProductResponse> UpdateAsync(UpdateBaseProductRequest request);
    }
}
