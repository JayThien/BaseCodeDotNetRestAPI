using ApplicationDomain.AuthenticationDomain;
using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.AuthenticationDomain.Requests;
using ApplicationDomain.AuthenticationDomain.Responses;
using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using ApplicationDomain.UserDomain.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.UserDomain
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRoleService roleService;
        public UserService(
            IMapper mapper,
            IUnitOfWork uow,
            IUserRepository userRepository,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IRoleService roleService
            ) : base(mapper, uow)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.roleService = roleService;
        }

        public async Task<ListUserResponse> ListAsync(ListUserRequest request)
        {
            ListUserResponse response = new ListUserResponse();
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                request.SearchTerm = StringUtil.GenerateSearchString(request.SearchTerm);
            }
            response.TotalRows = await this.userRepository
                .List(request)
                .MapQueryTo<UserBinding>(this._mapper)
                .CountAsync();
            response.PageNumber = request.PageNumber;
            response.Data = await this.userRepository
                .List(request)
                .MapQueryTo<UserBinding>(this._mapper)
                .OrderByDescending(p => p.Id)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();

            return response;

        }

        public async Task<UserDropdownResponse> Dropdown(UserDropdownRequest request)
        {
            if (string.IsNullOrEmpty(request.RoleName))
            {
                return new UserDropdownResponse()
                {
                    Data = await this.userRepository.GetEntitiesQueryable().MapQueryTo<UserDropdownBinding>(this._mapper).ToListAsync()
                };
            }
            var users = await this.userManager.GetUsersInRoleAsync(request.RoleName);
            if (users.Count == 0)
            {
                return new UserDropdownResponse()
                {
                    Data = new List<UserDropdownBinding>()
                };
            }
            return new UserDropdownResponse()
            {
                Data = users.Select(p => new UserDropdownBinding()
                {
                    Value = p.Id,
                    Label = p.Fullname,
                    AvatarURL = p.AvatarURL
                }).ToList()
            };
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUserRequest request)
        {
            User user = new User();
            this._mapper.Map(request, user);
            var result = await this.userManager.CreateAsync(user, $"{user.PhoneNumber}El");
            if (result.Succeeded)
            {
                var roleName = await this.roleManager.FindByIdAsync(request.RoleId.ToString());
                await this.userManager.AddToRoleAsync(user, roleName.Name.ToString());
                //await this.userManager.AddClaimAsync(user,
                //    new System.Security.Claims.Claim(ClaimType.RestaurantClaim, request.RestaurantId.ToString()));
            } else
            {
                throw new Exception(result.Errors.FirstOrDefault().Description);
            }
            return new CreateUserResponse() { Id = user.Id };
        }

        public async Task<UserDetailResponse> GetAsync(int id)
        {
            return null;
            //return await this.userRepository.Get(id);
        }

        public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
        {
            User user = await this.userManager.Users.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            this._mapper.Map(request, user);
            await this.userManager.UpdateAsync(user);
            await this.roleService.UpdateRoleOfUser(user, request.RoleId);
            await this._uow.SaveChangesAsync();
            return new UpdateUserResponse() { Id = user.Id };
        }

        public async Task<IEnumerable<int>> GetUserByRangePointAsync(int min, int max)
        {
            return await this.userRepository
                .GetEntitiesQueryable()
                .MapQueryTo<UserDetailResponse>(_mapper)
                .Where(p => p.Point >= min && p.Point <= max)
                .Select(p => p.Id)
                .ToListAsync();
        }
    }
}
