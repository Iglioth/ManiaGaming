using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class CategorieViewModel : ZoekViewModel
    {
        public List<CategorieDetailViewModel> CategorieDetailViewModels { get; set; } = new List<CategorieDetailViewModel>();
    }
}
