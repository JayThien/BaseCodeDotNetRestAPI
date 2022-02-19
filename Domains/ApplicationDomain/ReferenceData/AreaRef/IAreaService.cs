using ApplicationDomain.ReferenceData.AreaRef.Requests;
using ApplicationDomain.ReferenceData.AreaRef.Responses;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.AreaRef
{
    public interface IAreaService
    {
        Task<ListAreaResponse> ListAsync(ListAreaRequest request);
        Task<CreateAreaResponse> CreateAsync(CreateAreaRequest request);
        Task<AreaDetailResponse> GetByIdAsync(int id);
        Task<UpdateAreaResponse> UpdateAsync(UpdateAreaRequest request);
        Task<AreaDropdownResponse> Dropdown();
    }
}
