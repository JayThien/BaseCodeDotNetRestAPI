using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.BaseProductRef.Bindings;
using ApplicationDomain.ReferenceData.BaseProductRef.Requests;
using ApplicationDomain.ReferenceData.BaseProductRef.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.BaseProductRef
{
    public class BaseProductService : ServiceBase, IBaseProductService
    {
        private readonly IBaseProductRepository baseProductRepository;
        public BaseProductService(
            IMapper mapper,
            IUnitOfWork uow,
             IBaseProductRepository baseProductRepository
            ) : base(mapper, uow)
        {
            this.baseProductRepository = baseProductRepository;
        }

        public async Task<CreateBaseProductResponse> CreateAsync(CreateBaseProductRequest request)
        {
            BaseProduct baseProduct = new BaseProduct();
            this._mapper.Map(request, baseProduct);

            this.baseProductRepository.Create(baseProduct);
            await this._uow.SaveChangesAsync();

            return new CreateBaseProductResponse() { Id = baseProduct.Id };
        }

        public async Task<BaseProductDetailResponse> GetByIdAsync(int id)
        {
            return await this.baseProductRepository.GetEntitiesQueryable()
                .MapQueryTo<BaseProductDetailResponse>(this._mapper)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ListBaseProductResponse> ListAsync(ListBaseProductRequest request)
        {
            ListBaseProductResponse response = new ListBaseProductResponse();
            response.TotalRows = await this.baseProductRepository
                .List(request)
                .MapQueryTo<BaseProductBinding>(this._mapper)
                .CountAsync();
            response.PageNumber = request.PageNumber;
            response.Data = await this.baseProductRepository
                .List(request)
                .MapQueryTo<BaseProductBinding>(this._mapper)
                .OrderByDescending(p => p.Id)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();

            return response;
        }

        public async Task<UpdateBaseProductResponse> UpdateAsync(UpdateBaseProductRequest request)
        {
            var BaseProduct = await this.baseProductRepository.GetEntityByIdAsync(request.Id);
            this._mapper.Map(request, BaseProduct);
            this.baseProductRepository.Update(BaseProduct);
            await this._uow.SaveChangesAsync();

            return new UpdateBaseProductResponse() { Id = BaseProduct.Id };
        }
    }
}
