using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.AreaRef.Bindings;
using ApplicationDomain.ReferenceData.AreaRef.Requests;
using ApplicationDomain.ReferenceData.AreaRef.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.AreaRef
{
    public class AreaService : ServiceBase, IAreaService
    {
        private readonly IAreaRepository areaRepository;
        public AreaService(
            IMapper mapper,
            IUnitOfWork uow,
            IAreaRepository areaRepository
            ) : base(mapper, uow)
        {
            this.areaRepository = areaRepository;
        }

        public async Task<ListAreaResponse> ListAsync(ListAreaRequest request)
        {
            ListAreaResponse response = new ListAreaResponse();
            response.TotalRows = await this.areaRepository
                .List(request)
                .MapQueryTo<AreaBinding>(this._mapper)
                .CountAsync();
            response.PageNumber = request.PageNumber;
            response.Data = await this.areaRepository
                .List(request)
                .MapQueryTo<AreaBinding>(this._mapper)
                .OrderByDescending(p => p.Id)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();

            return response;
        }

        public async Task<CreateAreaResponse> CreateAsync(CreateAreaRequest request)
        {
            Area area = new Area();
            this._mapper.Map(request, area);

            this.areaRepository.Create(area);
            await this._uow.SaveChangesAsync();

            return new CreateAreaResponse() { Id = area.Id };
        }

        public async Task<UpdateAreaResponse> UpdateAsync(UpdateAreaRequest request)
        {
            var area = await this.areaRepository.GetEntityByIdAsync(request.Id);
            this._mapper.Map(request, area);
            this.areaRepository.Update(area);
            await this._uow.SaveChangesAsync();

            return new UpdateAreaResponse() { Id = area.Id };
        }

        public async Task<AreaDetailResponse> GetByIdAsync(int id)
        {
            return await this.areaRepository
                .GetEntitiesQueryable()
                .MapQueryTo<AreaDetailResponse>(this._mapper)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<AreaDropdownResponse> Dropdown()
        {
            return new AreaDropdownResponse()
            {
                Data = await this.areaRepository.GetEntitiesQueryable().MapQueryTo<AreaDropdownBinding>(this._mapper).ToListAsync()
            };
        }
    }
}
