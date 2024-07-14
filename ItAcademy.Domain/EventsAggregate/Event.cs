using System.ComponentModel.DataAnnotations;
using ItAcademy.Domain.BaseEntity;
using ItAcademy.Domain.OrderAggregate;
using ItAcademy.Domain.UserAggregate;

namespace ItAcademy.Domain.EventsAggregate
{
    public class Event : Entity
    {
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        public bool Approved { get; set; }
        [Display(Name = "StartDate")]
        public DateTimeOffset StartDate { get; set; }
        [Display(Name = "EndDate")]
        public DateTimeOffset EndDate { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Email")]
        public User User { get; set; }
        public List<Order> Orders { get; set; }
    }
}
