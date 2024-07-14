namespace ItAcademy.Application.Events.Response
{
    public class EventResponse
    {
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public bool Approved { get; set; }
        public string Email { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Image { get; set; }
    }
}
