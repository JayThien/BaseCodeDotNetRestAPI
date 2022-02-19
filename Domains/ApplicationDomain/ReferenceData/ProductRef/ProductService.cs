using ApplicationDomain.Entities;
using ApplicationDomain.OrderDomain.Models;
using ApplicationDomain.ReferenceData.ProductRef.Bindings;
using ApplicationDomain.ReferenceData.ProductRef.Requests;
using ApplicationDomain.ReferenceData.ProductRef.Responses;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.ProductRef
{
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(
            IMapper mapper,

            IUnitOfWork uow,
            IProductRepository productRepository
            ) : base(mapper, uow)
        {
            this.productRepository = productRepository;
        }
        public async Task<ListProductResponse> ListAsync(ListProductRequest request)
        {
            ListProductResponse response = new ListProductResponse();
            response.TotalRows = await this.productRepository
                .List(request)
                .MapQueryTo<ListProductBinding>(this._mapper)
                .CountAsync();
            response.PageNumber = request.PageNumber;
            response.Data = await this.productRepository
                .List(request)
                .MapQueryTo<ListProductBinding>(this._mapper)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();

            return response;
        }

        //public async Task ChangeMenuItemStatusAsync(int productId)
        //{
        //    var menuItem = await this._productRepository.GetEntityByIdAsync(productId);
        //    menuItem.IsAvailable = !menuItem.IsAvailable;
        //    this._productRepository.Update(menuItem);
        //    await _uow.SaveChangesAsync();
        //}

        public async Task<CreateProductResponse> CreateAsync(CreateProductRequest request)
        {
            Product product = new Product();
            this._mapper.Map(request, product);
            this.productRepository.Create(product);
            await this._uow.SaveChangesAsync();
            return new CreateProductResponse() { Id = product.Id };
        }

        public async Task<ProductDetailResponse> GetByIdAsync(int id)
        {
            var rs = await this.productRepository.GetEntitiesQueryable()
                .MapQueryTo<ProductDetailResponse>(this._mapper)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            return rs;
        }

        public async Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request)
        {
            var product = await this.productRepository.GetEntityByIdAsync(request.Id);
            this._mapper.Map(request, product);
            this.productRepository.Update(product);
            await this._uow.SaveChangesAsync();
            return new UpdateProductResponse() { Id = product.Id };
        }
 
        public async Task DeleteAsync(int id)
        {
            await this.productRepository.DeleteAsync(id);
            await this._uow.SaveChangesAsync();
        }

        public async Task<List<AllProductBinding>> GetAllAsync(int restaurantId)
        {
            var products = this.productRepository.GetEntitiesQueryable();
            List<AllProductBinding> response = new List<AllProductBinding>();
            foreach (Category c in (Category[])Enum.GetValues(typeof(Category)))
            {
                var subCategories = SubCategoryMap.MapFromCategory(c);
                List<SubCategoryBinding> items = new List<SubCategoryBinding>();
                subCategories.ForEach(subCategory =>
                {
                    items.Add(new SubCategoryBinding()
                    {
                        SubCategory = subCategory,
                        SubCategoryName = SubCategoryMap.ToName(subCategory),
                        Products = products.MapQueryTo<ProductBinding>(this._mapper)
                        .Where(p => p.SubCategory == subCategory)
                        .ToList()
                    });
                });
                response.Add(new AllProductBinding()
                {
                    Category = c,
                    CategoryName = CategoryMap.ToName(c),
                    SubCategoryItems = items
                });
            }
            return response;
        }

        public async Task<List<OrderProductDTO>> GetOrderProducts(int menuId, SubCategory subCategory)
        {
            return await this.productRepository
                .GetEntitiesQueryable()
                .MapQueryTo<OrderProductDTO>(this._mapper)
                .Where(p => p.MenuId == menuId && p.SubCategory == subCategory)
                .ToListAsync();
        }
    }
}
