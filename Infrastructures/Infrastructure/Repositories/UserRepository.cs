using ApplicationDomain.AuthenticationDomain;
using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.AuthenticationDomain.Requests;
using ApplicationDomain.Entities;
using ApplicationDomain.UserDomain.Responses;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {

        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            this._userManager = userManager;
            this._dbContext = dbContext;
        }

        //public IQueryable List(ListUserRequest requestData)
        //{
        //    return this.dbSet.Where(p => (
        //    string.IsNullOrEmpty(requestData.SearchTerm) 
        //        || p.SearchName.Contains(requestData.SearchTerm) 
        //        || p.PhoneNumber.Contains(requestData.SearchTerm)
        //    ));
        //}

        public IQueryable List(ListUserRequest requestData)
        {
            var query = (from uRole in _dbContext.UserRoles
                         from user in _userManager.Users
                         from role in _dbContext.Roles
                             //from claims in _dbContext.UserClaims.Where(p => p.ClaimType == "Restaurant")
                         where uRole.UserId == user.Id && role.Id == uRole.RoleId
                            && (string.IsNullOrEmpty(requestData.SearchTerm)
                                 || user.SearchName.Contains(requestData.SearchTerm)
                                 || user.PhoneNumber.Contains(requestData.SearchTerm)
                             )
                         //&& user.Id == claims.UserId
                         select new UserBinding
                         {
                             Id = user.Id,
                             Fullname = user.Fullname,
                             Email = user.Email,
                             PhoneNumber = user.PhoneNumber,
                             RoleId = role.Id,
                             Status = user.Status,
                             AvatarURL = user.AvatarURL,
                             DateOfBirth = user.DateOfBirth,
                             Gender = user.Gender,
                             RoleName = role.Name
                         });
            return query;
        }
    }
}
