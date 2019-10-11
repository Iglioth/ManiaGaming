using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
        public int Soort { get; set; }
        public int CategorieId { get; set; }
        public string Omschrijving { get; set; }
        public List<CategorieDetailViewModel> CategorieList { get; set; }
        public int Prijs { get; set; }
    }
}
