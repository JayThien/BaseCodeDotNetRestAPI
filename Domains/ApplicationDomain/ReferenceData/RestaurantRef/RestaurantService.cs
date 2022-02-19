using ApplicationDomain.Entities;
using ApplicationDomain.ReferenceData.RestaurantRef.Bindings;
using ApplicationDomain.ReferenceData.RestaurantRef.Requests;
using ApplicationDomain.ReferenceData.RestaurantRef.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.RestaurantRef
{
    public class RestaurantService : ServiceBase, IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;
        public RestaurantService(
            IMapper mapper,
            IUnitOfWork uow,
             IRestaurantRepository restaurantRepository
            ) : base(mapper, uow)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<CreateRestaurantResponse> CreateAsync(CreateRestaurantRequest request)
        {
            Restaurant restaurant = new Restaurant();
            this._mapper.Map(request, restaurant);
            restaurant.IsOpening = true;

            this.restaurantRepository.Create(restaurant);
            await this._uow.SaveChangesAsync();

            return new CreateRestaurantResponse() { Id = restaurant.Id };
        }

        public async Task<RestaurantDetailResponse> GetByIdAsync(int id)
        {
            return await this.restaurantRepository.GetEntitiesQueryable()
                .MapQueryTo<RestaurantDetailResponse>(this._mapper)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ListRestaurantResponse> ListAsync(ListRestaurantRequest request)
        {
            ListRestaurantResponse response = new ListRestaurantResponse();
            response.TotalRows = await this.restaurantRepository
                .List(request)
                .MapQueryTo<RestaurantBinding>(this._mapper)
                .CountAsync();
            response.PageNumber = request.PageNumber;
            response.Data = await this.restaurantRepository
                .List(request)
                .MapQueryTo<RestaurantBinding>(this._mapper)
                .OrderByDescending(p => p.Id)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();

            return response;
        }

        public async Task<UpdateRestaurantResponse> UpdateAsync(UpdateRestaurantRequest request)
        {
            var restaurant = await this.restaurantRepository.GetEntityByIdAsync(request.Id);
            this._mapper.Map(request, restaurant);
            this.restaurantRepository.Update(restaurant);
            await this._uow.SaveChangesAsync();

            return new UpdateRestaurantResponse() { Id = restaurant.Id };
        }

        public async Task<RestaurantDropdownResponse> GetDropdowmAsync(RestaurantDropdownRequest request)
        {
            return new RestaurantDropdownResponse()
            {
                Data = await this.restaurantRepository
                .GetEntitiesQueryable()
                .MapQueryTo<RestaurantDropdownBinding>(this._mapper)
                .ToListAsync()
            };
        }
    }
}
