using System;
using System.ComponentModel.DataAnnotations;

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
