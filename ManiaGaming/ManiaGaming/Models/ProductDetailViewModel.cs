using System.Collections.Generic;

namespace ManiaGaming.Models
{
    public class ProductDetailViewModel : ZoekViewModel
    {
        public int Id { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
        public string Soort { get; set; }
        public int CategorieId { get; set; }
        public string Omschrijving { get; set; }
        public List<CategorieDetailViewModel> CategorieList { get; set; }
        public List<string> SoortList { get; set; }
        public string Prijs { get; set; }
        public bool Actief { get; set; }
        public string CategorieNaam { get; set; }
        public bool Tweedehands { get; set; }
        public string ImagePath { get; set; }
    }
}
