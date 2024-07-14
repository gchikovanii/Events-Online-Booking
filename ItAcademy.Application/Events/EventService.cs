using ItAcademy.Application.Events.Repositories;
using ItAcademy.Application.Events.Request;
using ItAcademy.Application.Events.Response;
using ItAcademy.Domain.EventsAggregate;
using Mapster;

namespace ItAcademy.Application.Events
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventResponse> GetEventForAdmin(CancellationToken token, int eventId)
        {
            var response = await _eventRepository.GetEventsForAdminById(token, eventId).ConfigureAwait(false);
            return response.Adapt<EventResponse>();
        }
        public async Task<IEnumerable<EventResponse>> GetEvenstForAdmin(CancellationToken token)
        {
            var events = await _eventRepository.GetEventsForAdmin(token).ConfigureAwait(false);
            return events;
        }
        public async Task<EventResponse> GetEvent(CancellationToken token, int eventId)
        {
            var response = await _eventRepository.GetEventById(token, eventId).ConfigureAwait(false);
            return response.Adapt<EventResponse>();
        }
        public async Task<IEnumerable<EventResponse>> GetEvents(CancellationToken token)
        {
            var events = await _eventRepository.GetEvents(token).ConfigureAwait(false);
            return events.Adapt<IEnumerable<EventResponse>>();
        }

        public async Task<int> AddEvent(CancellationToken token, EventRequest request, string userName)
        {
            var ev = request.Adapt<Event>();
            return await _eventRepository.AddEvent(token, ev, userName).ConfigureAwait(false);
        }
        public async Task<bool> ApproveEvent(CancellationToken token, int eventId)
        {
            var result = await _eventRepository.ApproveEvent(token, eventId).ConfigureAwait(false);
            return result;
        }
        public async Task<EventResponse> UpdateEvent(CancellationToken token, UpdateEventRequest request, int eventId, string userName)
        {
            var ev = request.Adapt<Event>();
            var result = await _eventRepository.UpdateEvent(token, ev, eventId, userName).ConfigureAwait(false);
            return result.Adapt<EventResponse>();
        }
        public async Task<bool> RemoveEvent(CancellationToken token, int eventId)
        {
            return await _eventRepository.DeleteEvent(token, eventId).ConfigureAwait(false);
        }
    }
}
