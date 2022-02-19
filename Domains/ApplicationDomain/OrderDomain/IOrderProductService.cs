using ApplicationDomain.OrderDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.IServices
{
    public interface IOrderProductService
    {
        Task AddProductToOrder(List<OrderProductDTO> request, int orderId);
    }
}
