﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
        public int Soort { get; set; }
        public int CategorieId { get; set; }
        public string Omschrijving { get; set; }
        public decimal Prijs { get; set; }
    }
}
