using ApplicationDomain.ReferenceData.RestaurantRef.Requests;
using ApplicationDomain.ReferenceData.RestaurantRef.Responses;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.RestaurantRef
{
    public interface IRestaurantService
    {
        Task<ListRestaurantResponse> ListAsync(ListRestaurantRequest request);
        Task<CreateRestaurantResponse> CreateAsync(CreateRestaurantRequest request);
        Task<RestaurantDetailResponse> GetByIdAsync(int id);
        Task<UpdateRestaurantResponse> UpdateAsync(UpdateRestaurantRequest request);
        Task<RestaurantDropdownResponse> GetDropdowmAsync(RestaurantDropdownRequest request);
    }
}
