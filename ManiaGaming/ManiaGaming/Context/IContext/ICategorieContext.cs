using System;
using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.IContext
{
    public interface ICategorieContext : IGenericQueries<Categorie>
    {
        bool AddStock(Product product);
    }
}
