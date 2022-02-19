using ApplicationDomain.AuthenticationDomain.Requests;
using ApplicationDomain.Entities; 
using ApplicationDomain.UserDomain.Responses;
using AspNetCore.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.AuthenticationDomain
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        IQueryable List(ListUserRequest requestData);
        //Task<UserDetailResponse> Get(int id);
    }
}
