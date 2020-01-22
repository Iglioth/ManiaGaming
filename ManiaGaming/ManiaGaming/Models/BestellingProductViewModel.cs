using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class BestellingProductViewModel : ZoekViewModel
    {
        public List<BestellingProductDetailViewModel> BestellingProductDetailViewModels { get; set; } = new List<BestellingProductDetailViewModel>();
    }
}
