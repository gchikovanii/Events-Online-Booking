using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.UserAggregate;

namespace ItAcademy.Application.Orders.Responses
{
    public class OrderResponse
    {
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
    }
}
