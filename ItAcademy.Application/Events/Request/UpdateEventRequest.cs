﻿namespace ItAcademy.Application.Events.Request
{
    public class UpdateEventRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public bool Approved { get; set; }
        public string Image { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
