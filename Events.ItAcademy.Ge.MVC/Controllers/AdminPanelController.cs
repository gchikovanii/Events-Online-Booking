using ItAcademy.Application.Accounts;
using ItAcademy.Application.Events;
using ItAcademy.Application.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Events.ItAcademy.Ge.MVC.Controllers
{
    public class AdminPanelController : Controller
    {
        #region Ctor
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IEventService _eventService;

        public AdminPanelController(IUserService userService, IOrderService orderService, IEventService eventService)
        {
            _userService = userService;
            _orderService = orderService;
            _eventService = eventService;
        }
        #endregion
        public async Task<IActionResult> Index(CancellationToken token)
        {
            var orders = await _eventService.GetEvenstForAdmin(token).ConfigureAwait(false);
            return View(orders);
        }
        public async Task<IActionResult> Users(CancellationToken token)
        {
            var users = await _userService.ShowActiveUsers(token).ConfigureAwait(false);
            return View(users);
        }
        public async Task<IActionResult> Orders(CancellationToken token)
        {
            var orders = await _orderService.GetAllOrdersForAdmin(token).ConfigureAwait(false);
            return View(orders);
        }
        //public async Task<IActionResult> Events(CancellationToken token)
        //{
        //    var orders = await _eventService.GetEvenstForAdmin(token).ConfigureAwait(false);
        //    return View(orders);
        //}

    }
}
