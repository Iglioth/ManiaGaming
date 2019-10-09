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
        public Categorie Categorie { get; set; }
        public string Omschrijving { get; set; }
        public int Prijs { get; set; }
        public string soort { get; set; }
    }
}
