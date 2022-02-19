using ApplicationDomain.OrderDomain.Requests;
using ApplicationDomain.OrderDomain.Responses;
using System.Threading.Tasks;

namespace ApplicationDomain.IServices
{
    public interface IOrderService
    {
        Task<OrderResponse> Order(OrderRequest request);
    }
}
