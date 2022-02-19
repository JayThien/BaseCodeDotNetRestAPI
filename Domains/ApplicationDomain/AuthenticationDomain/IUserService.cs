using ApplicationDomain.AuthenticationDomain.Requests;
using ApplicationDomain.AuthenticationDomain.Responses;
using ApplicationDomain.Common; 
using ApplicationDomain.UserDomain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.AuthenticationDomain
{
    public interface IUserService
    {
        Task<ListUserResponse> ListAsync(ListUserRequest request);
        Task<UserDropdownResponse> Dropdown(UserDropdownRequest request);
        Task<UserDetailResponse> GetAsync(int id);
        Task<CreateUserResponse> CreateAsync(CreateUserRequest request);
        Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request);
        Task<IEnumerable<int>> GetUserByRangePointAsync(int min, int max);
    }
}
