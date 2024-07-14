// Copyright (C) TBC Bank. All Rights Reserved.

namespace Events.ItAcademy.Ge.MVC.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}