using ItAcademy.Application.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Events.ItAcademy.Ge.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
