using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;
using System.Collections.Generic;

namespace ManiaGaming.Context.IContext
{
    public interface IBestellingContext : IGenericQueries<Bestelling>
    {

        bool Bestellen(List<Product> Producten, long KlantID);
        List<BestellingProduct> GetAllById(long id);
    }
   
    
}
