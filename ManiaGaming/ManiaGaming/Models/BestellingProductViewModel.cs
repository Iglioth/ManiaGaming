using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class BestellingProductViewModel
    {
        public List<BestellingProductDetailViewModel> BestellingProductDetailViewModels { get; set; } = new List<BestellingProductDetailViewModel>();
    }
}
