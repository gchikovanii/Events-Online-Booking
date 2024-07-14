using ItAcademy.Application.Events.Request;
using ItAcademy.Application.Events.Response;

namespace ItAcademy.Application.Events
{
    public interface IEventService
    {
        Task<EventResponse> GetEventForAdmin(CancellationToken token, int eventId);
        Task<IEnumerable<EventResponse>> GetEvenstForAdmin(CancellationToken token);
        Task<EventResponse> GetEvent(CancellationToken token, int eventId);
        Task<IEnumerable<EventResponse>> GetEvents(CancellationToken token);
        Task<int> AddEvent(CancellationToken token, EventRequest request, string userName);
        Task<bool> ApproveEvent(CancellationToken token, int eventId);
        Task<EventResponse> UpdateEvent(CancellationToken token, UpdateEventRequest request, int eventId, string userName);
        Task<bool> RemoveEvent(CancellationToken token, int eventId);
    }
}
