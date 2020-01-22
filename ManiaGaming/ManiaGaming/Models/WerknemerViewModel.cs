using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class WerknemerViewModel : ZoekViewModel
    {
        public List<WerknemerDetailViewModel> WerknemerDetailViewModels { get; set; }

        public List<FiliaalDetailViewModel> FiliaalList { get; set; }
    }
}
