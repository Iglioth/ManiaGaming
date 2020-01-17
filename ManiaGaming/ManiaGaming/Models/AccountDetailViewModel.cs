using System.ComponentModel.DataAnnotations;

namespace ManiaGaming.Models
{
    public class AccountDetailViewModel : ZoekViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        // public string NormalizedEmail { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string AchterNaam { get; set; }
        public string Rol { get; set; }
        public bool Actief { get; set; }
    }
}
