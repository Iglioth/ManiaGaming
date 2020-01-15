using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class ProductViewModel : ZoekViewModel
    {
        public List<ProductDetailViewModel> ProductDetailViewModels { get; set; } = new List<ProductDetailViewModel>();
        public List<CategorieDetailViewModel> CategorieList { get; set; }
        public List<string> SoortList { get; set; }
    }
}
