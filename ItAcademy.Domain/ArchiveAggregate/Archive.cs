using ItAcademy.Domain.BaseEntity;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.OrderAggregate;

namespace ItAcademy.Domain.ArchiveAggregate
{
    public class Archive : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public bool Approved { get; set; } 
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Image { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int UserId { get; set; }
    }
}
