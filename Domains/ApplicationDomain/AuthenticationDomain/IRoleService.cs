using ApplicationDomain.AuthenticationDomain.Responses;
using ApplicationDomain.Entities;
using System.Threading.Tasks;

namespace ApplicationDomain.AuthenticationDomain
{
    public interface IRoleService
    {
        Task<RoleDropdownResponse> Dropdown();
        Task UpdateRoleOfUser(User user, int roleId);
    }
}
