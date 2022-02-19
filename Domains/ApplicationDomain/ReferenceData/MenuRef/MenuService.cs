using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.MenuRef.Bindings;
using ApplicationDomain.ReferenceData.MenuRef.Requests;
using ApplicationDomain.ReferenceData.MenuRef.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.MenuRef
{
    public class MenuService : ServiceBase, IMenuService
    {
        private readonly IMenuRepository menuRepository;
        public MenuService(
            IMapper mapper,
            IUnitOfWork uow,
            IMenuRepository menuRepository
            ) : base(mapper, uow)
        {
            this.menuRepository = menuRepository;
        }

        public async Task<ListMenuResponse> ListAsync()
        {
            return new ListMenuResponse()
            {
                Data = await this.menuRepository
                .GetEntitiesQueryable()
                .MapQueryTo<ListMenuBinding>(this._mapper)
                .ToListAsync()
            };
        }

        public async Task<CreateMenuResponse> CreateAsync(CreateMenuRequest request)
        {
            Menu Menu = new Menu();
            this._mapper.Map(request, Menu);

            this.menuRepository.Create(Menu);
            await this._uow.SaveChangesAsync();

            return new CreateMenuResponse() { Id = Menu.Id };
        }

        public async Task<UpdateMenuResponse> UpdateAsync(UpdateMenuRequest request)
        {
            var Menu = await this.menuRepository.GetEntityByIdAsync(request.Id);
            this._mapper.Map(request, Menu);
            this.menuRepository.Update(Menu);
            await this._uow.SaveChangesAsync();

            return new UpdateMenuResponse() { Id = Menu.Id };
        }

        public async Task<MenuDetailResponse> GetByIdAsync(int id)
        {
            return await this.menuRepository
                .GetEntitiesQueryable()
                .MapQueryTo<MenuDetailResponse>(this._mapper)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
