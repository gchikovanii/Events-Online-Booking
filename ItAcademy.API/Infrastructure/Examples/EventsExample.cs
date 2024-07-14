using ItAcademy.Application.Events.Response;
using Swashbuckle.AspNetCore.Filters;

namespace ItAcademy.API.Infrastructure.Examples
{
    public class EventsExample : IMultipleExamplesProvider<EventResponse>
    {
        public IEnumerable<SwaggerExample<EventResponse>> GetExamples()
        {
            yield return SwaggerExample.Create("Ex.1", new EventResponse()
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
            });
            yield return SwaggerExample.Create("Ex.2", new EventResponse()
            {
                Id = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(3),
                Status = true,
                Approved = true,
                CreatedAt = DateTime.Now.AddDays(-1),
                Description = "Description of second event",
                Title = "Bashiacuki",
                Location = "Georgia, Tbilisi, rustaveli",
                Price = 45,
                Quantity = 150,
                //Images = new EventImageResponse()
                //{
                //    ImageUrl = "Photos Url Cloudinaryze",
                //    CloudinaryId = "Rand",
                //    EventId = 1
                //}.ToList()
            });
        }
    }
}
