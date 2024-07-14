using System.ComponentModel.DataAnnotations;

namespace ItAcademy.Application.Events.Request
{
    public class EventRequest
    {
        [Required(ErrorMessage ="Required")]
        [StringLength(100,MinimumLength = 5, ErrorMessage ="5idan 10dme")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "5idan 1000dme")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTimeOffset StartDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public DateTimeOffset EndDate { get; set; }
    }
}
