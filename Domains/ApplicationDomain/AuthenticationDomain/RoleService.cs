using ApplicationDomain.AuthenticationDomain;
using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.AuthenticationDomain.Responses;
using ApplicationDomain.Entities;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApplicationDomain.UserDomain
{
    public class RoleService : ServiceBase, IRoleService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        public RoleService(
            IMapper mapper,
            IUnitOfWork uow,
            IUserRepository userRepository,
            UserManager<User> userManager,
            RoleManager<Role> roleManager
            ) : base(mapper, uow)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<RoleDropdownResponse> Dropdown()
        {
            return new RoleDropdownResponse()
            {
                Data = await this.roleManager.Roles.MapQueryTo<RoleDropdownBinding>(this._mapper).ToListAsync()
            };
        }

        public async Task UpdateRoleOfUser(User user, int roleId)
        {
            var newRole = await this.roleManager.FindByIdAsync(roleId.ToString());
            if (await this.userManager.IsInRoleAsync(user, newRole.Name))
            {
                return;
            }
            var oldRole = await this.userManager.GetRolesAsync(user);
            await this.userManager.RemoveFromRoleAsync(user, oldRole[0]);
            await this.userManager.AddToRoleAsync(user, newRole.Name);
        }
    }
}
