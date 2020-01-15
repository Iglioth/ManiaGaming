using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class KlantDetailViewModel : AccountDetailViewModel
    {
        public int KlantId { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime Geboortedatum { get; set; }
        public int Punten { get; set; }

    }
}
