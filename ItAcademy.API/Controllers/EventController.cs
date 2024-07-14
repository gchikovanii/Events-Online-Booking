using System.Security.Claims;
using ItAcademy.API.Infrastructure.Examples;
using ItAcademy.Application.Events;
using ItAcademy.Application.Events.Request;
using ItAcademy.Application.Events.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
namespace ItAcademy.API.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        [Produces("application/json")]
        [ProducesResponseType(typeof(EventResponse), 200)]
        [HttpGet("{eventId}")]
        public async Task<EventResponse> GetEvent(CancellationToken token, int eventId)
        {
            return await _eventService.GetEvent(token, eventId).ConfigureAwait(false);
        }
        
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<EventResponse>),StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK,typeof(EventsExample))]
        [HttpGet("all")]
        public async Task<IEnumerable<EventResponse>> GetEvents(CancellationToken token)
        {
            return await _eventService.GetEvents(token).ConfigureAwait(false);
        }
        [HttpPost("add")]
        public async Task<int> AddEvent(CancellationToken token, EventRequest request,string userName)
        {
            return await _eventService.AddEvent(token, request, userName).ConfigureAwait(false);
        }
        [HttpPut("update/{eventId}")]
        public async Task<EventResponse> UpdateEvent(CancellationToken token, UpdateEventRequest request, int eventId)
        {
            return await _eventService.UpdateEvent(token, request, eventId, UserName()).ConfigureAwait(false);
        }

        #region UserName
        private string UserName()
        {
            return HttpContext.User.FindFirstValue("UserName");
        }
        #endregion
    }
}
