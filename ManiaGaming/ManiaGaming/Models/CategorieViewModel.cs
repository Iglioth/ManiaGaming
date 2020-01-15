using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class CategorieViewModel : ZoekViewModel
    {
        public List<CategorieDetailViewModel> CategorieDetailViewModels { get; set; } = new List<CategorieDetailViewModel>();
    }
}
