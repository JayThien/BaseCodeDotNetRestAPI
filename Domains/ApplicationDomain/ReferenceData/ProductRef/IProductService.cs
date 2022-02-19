using ApplicationDomain.Entities;
using ApplicationDomain.OrderDomain.Models;
using ApplicationDomain.ReferenceData.ProductRef.Bindings;
using ApplicationDomain.ReferenceData.ProductRef.Requests;
using ApplicationDomain.ReferenceData.ProductRef.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.ReferenceData.ProductRef
{
    public interface IProductService
    {
        Task<ListProductResponse> ListAsync(ListProductRequest request);
        Task<CreateProductResponse> CreateAsync(CreateProductRequest request);
        Task<ProductDetailResponse> GetByIdAsync(int id);
        Task<UpdateProductResponse> UpdateAsync(UpdateProductRequest request);
        Task<List<OrderProductDTO>> GetOrderProducts(int menuId, SubCategory subCategory);
        Task DeleteAsync(int id);
        Task<List<AllProductBinding>> GetAllAsync(int restaurantId);
    }
}
