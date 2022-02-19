using ApplicationDomain.Entities;
using ApplicationDomain.IRepositories;
using ApplicationDomain.IServices;
using ApplicationDomain.OrderDomain.Models;
using AspNetCore.UnitOfWork;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.Services
{
    public class OrderProductService : ServiceBase, IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductService(
            IMapper mapper,

            IUnitOfWork uow,
            IOrderProductRepository orderProductRepository
            ) : base(mapper, uow)
        {
            this._orderProductRepository = orderProductRepository;
        }

        public async Task AddProductToOrder(List<OrderProductDTO> request, int orderId)
        {
            var orderProducts = new List<OrderProduct>();
            this._mapper.Map(request, orderProducts);
            orderProducts.ForEach(product => { product.OrderId = orderId; product.Id = 0; });
            await this._orderProductRepository.CreateRangeAsync(orderProducts);
            await this._uow.SaveChangesAsync();
        }
    }
}
