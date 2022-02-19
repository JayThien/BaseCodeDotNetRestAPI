using ApplicationDomain.ReferenceData.MenuRef.Requests;
using ApplicationDomain.ReferenceData.MenuRef.Responses;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.MenuRef
{
    public interface IMenuService
    {
        Task<ListMenuResponse> ListAsync();
        Task<CreateMenuResponse> CreateAsync(CreateMenuRequest request);
        Task<MenuDetailResponse> GetByIdAsync(int id);
        Task<UpdateMenuResponse> UpdateAsync(UpdateMenuRequest request);
    }
}
