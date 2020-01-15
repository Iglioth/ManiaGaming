﻿using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.IContext
{
    public interface IBestellingContext : IGenericQueries<Bestelling>
    {

        bool Bestellen(List<Product> Producten, long KlantID);
        List<BestellingProduct> GetAllById(long id);
    }
   
    
}
