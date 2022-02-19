using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using ApplicationDomain.IServices;
using ApplicationDomain.PromotionDomain.Bindings;
using ApplicationDomain.PromotionDomain.Requests;
using ApplicationDomain.PromotionDomain.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Services
{
    public class PromotionService : ServiceBase, IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IUserPromotionService userPromotionService;
        public PromotionService(
            IMapper mapper,
            IUnitOfWork uow,
            IPromotionRepository promotionRepository,
             IUserPromotionService userPromotionService
            ) : base(mapper, uow)
        {
            this._promotionRepository = promotionRepository;
            this.userPromotionService = userPromotionService;
        }

        public async Task<ListPromotionResponse> ListAsync(ListPromotionRequest request)
        {
            ListPromotionResponse response = new ListPromotionResponse();
            response.TotalRows = await this._promotionRepository
                .List(request)
                .MapQueryTo<PromotionBinding>(this._mapper)
                .CountAsync();
            response.PageNumber = request.PageNumber;
            response.Data = await this._promotionRepository
                .List(request)
                .MapQueryTo<PromotionBinding>(this._mapper)
                .OrderByDescending(p => p.Id)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();

            return response;

        }

        public async Task<CreatePromotionResponse> CreateAsync(CreatePromotionRequest request)
        {
            Promotion promotion = new Promotion();
            this._mapper.Map(request, promotion);

            this._promotionRepository.Create(promotion);
            await this._uow.SaveChangesAsync();

            await this.userPromotionService.CreateAsync(promotion.Id, request.MinPoint, request.MaxPoint);
            return new CreatePromotionResponse() { Id = promotion.Id };
        }

        public async Task<PromotionDetailResponse> GetAsync(int id)
        {
            return await this._promotionRepository
                .GetEntitiesQueryable()
                .MapQueryTo<PromotionDetailResponse>(this._mapper)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
