using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class OrderViewModel : ZoekViewModel
    {
        public List<OrderDetailViewModel> Orders { get; set; }
    }
}
