using System;

namespace ManiaGaming.Models
{
    public class ErrorViewModel : ZoekViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}