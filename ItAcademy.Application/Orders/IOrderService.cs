using ItAcademy.Application.Orders.Requests;
using ItAcademy.Application.Orders.Responses;
using ItAcademy.Domain.OrderAggregate;

namespace ItAcademy.Application.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllOrders(CancellationToken token, string userName);
        Task<IEnumerable<Order>> GetAllOrdersForAdmin(CancellationToken token);
        Task<bool> MakeOrder(CancellationToken token, OrderRequest order, int eventId);
    }
}
