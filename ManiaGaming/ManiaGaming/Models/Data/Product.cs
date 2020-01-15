using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Product
    {
        public int Id { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
        public string Soort { get; set; }
        public int CategorieId { get; set; }
        public string Omschrijving { get; set; }
        public string Prijs { get; set; }
        public bool Actief { get; set; }
        public string CategorieNaam { get; set; }
        public bool Tweedehands { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }

        
    }
}
