using ItAcademy.Application.Events.Response;
using ItAcademy.Domain.EventsAggregate;

namespace ItAcademy.Application.Events.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetEventsForAdminById(CancellationToken token, int eventId);
        Task<IEnumerable<EventResponse>> GetEventsForAdmin(CancellationToken token);
        Task<Event> GetEventById(CancellationToken token, int eventId);
        Task<IEnumerable<EventResponse>> GetEvents(CancellationToken token);
        Task<int> AddEvent(CancellationToken token, Event request, string userName);
        Task<bool> ApproveEvent(CancellationToken token, int eventId);
        Task<Event> UpdateEvent(CancellationToken token, Event request, int eventId, string userName);
        Task<bool> DeleteEvent(CancellationToken token, int eventId);
    }
}
