using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Product
    {
        int ProductId { get; set; }
        int Aantal { get; set; }
        string Naam { get; set; }
        string Categorie { get; set; }
        string Omschrijving { get; set; }
        int Prijs { get; set; }
    }
}
