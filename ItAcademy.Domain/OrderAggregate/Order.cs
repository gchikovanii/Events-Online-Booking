using System.ComponentModel.DataAnnotations;
using ItAcademy.Domain.BaseEntity;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.UserAggregate;

namespace ItAcademy.Domain.OrderAggregate
{
    public class Order : Entity
    {
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }
        public int EventId { get; set; }
        [Display(Name = "Event")]
        public Event Event { get; set; }
        public int UserId { get; set; }
        [Display(Name = "User")]
        public User User { get; set; }
    }
}
