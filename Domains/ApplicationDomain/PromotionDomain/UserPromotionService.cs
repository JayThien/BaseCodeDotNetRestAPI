using ApplicationDomain.AuthenticationDomain;
using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using ApplicationDomain.IServices; 
using AspNetCore.UnitOfWork;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Services
{
    public class UserPromotionService : ServiceBase, IUserPromotionService
    {
        private readonly IUserPromotionRepository userpromotionRepository;
        private readonly IUserService userService;
        public UserPromotionService(
            IMapper mapper,
            IUnitOfWork uow,
            IUserPromotionRepository userpromotionRepository,
            IUserService userService
            ) : base(mapper, uow)
        {
            this.userpromotionRepository = userpromotionRepository;
            this.userService = userService;
        }
        public async Task CreateAsync(int promotionId, int min, int max)
        {
            var usersId = await this.userService.GetUserByRangePointAsync(min, max);
            usersId.ToList().ForEach(
                userId => this.userpromotionRepository.Create(new UserPromotion()
                {
                    UserId = userId,
                    PromotionId = promotionId,
                    IsApplied = false
                }));
            await this._uow.SaveChangesAsync();
        }
    }
}
