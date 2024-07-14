using ItAcademy.Application.Events;
using ItAcademy.Application.Events.Request;
using ItAcademy.Application.Events.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace Events.ItAcademy.Ge.MVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index(CancellationToken token)
        {
            var data = await _eventService.GetEvents(token).ConfigureAwait(false);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(CancellationToken token,int id)
        {
            var ev = await _eventService.GetEvent(token,id).ConfigureAwait(false);
            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CancellationToken token, EventRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            await _eventService.AddEvent(token, request, "gio").ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }
    }
}
