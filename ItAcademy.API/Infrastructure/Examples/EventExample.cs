using ItAcademy.Application.Events.Response;
using Swashbuckle.AspNetCore.Filters;

namespace ItAcademy.API.Infrastructure.Examples
{
    public class EventExample : IExamplesProvider<EventResponse>
    {
        public EventResponse GetExamples()
        {
            return new EventResponse()
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(5),
                Status = true,
                Approved = true,
                CreatedAt = DateTime.Now.AddDays(-2),
                Description = "Description of event",
                Title = "Shavnabadas koncerti",
                Location = "Georgia, Tbilisi, Mebrdzolta qucha 55",
                Price = 25,
                Quantity = 22,
                //Images = new EventImageResponse()
                //{
                //    ImageUrl = "Photos Url Cloudinaryze",
                //    CloudinaryId = "Rand",
                //    EventId = 1
                //}.ToList()
            };
        }
    }
}
