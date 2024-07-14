using System.Security.Claims;
using ItAcademy.Application.Orders;
using ItAcademy.Application.Orders.Requests;
using ItAcademy.Application.Orders.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("orders")]
        public async Task<IEnumerable<OrderResponse>> GetOrders(CancellationToken token)
        {
            return await _orderService.GetAllOrders(token, UserName()).ConfigureAwait(false);
        }
        [Authorize]
        [HttpPost("make-order")]
        public async Task<bool> AddEvent(CancellationToken token, OrderRequest request, int eventId)
        {
            return await _orderService.MakeOrder(token, request, eventId).ConfigureAwait(false);
        }
        #region UserName
        private string UserName()
        {
            return HttpContext.User.FindFirstValue("UserName");
        }
        #endregion
    }
}
