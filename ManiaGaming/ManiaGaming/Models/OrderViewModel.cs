using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class OrderViewModel : ZoekViewModel
    {
        public List<OrderDetailViewModel> Orders { get; set; }
    }
}
