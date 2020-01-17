using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;
using System.Collections.Generic;

namespace ManiaGaming.Context.IContext
{
    public interface IProductContext : IGenericQueries<Product>
    {
        bool VeranderStock(long id, Product obj);
        bool UpdateVoorraad(int id, int aantal);
        List<Product> GetAllGames();
        List<Product> GetAllAccesoires();
        List<Product> GetAllMerchandise();
        List<Product> GetAllConsole();
        List<Product> Zoeken(string Zoekterm);
    }
}
