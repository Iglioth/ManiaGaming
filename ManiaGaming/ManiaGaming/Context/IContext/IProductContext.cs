using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.IContext
{
    public interface IProductContext : IGenericQueries<Product>
    {
        bool RemoveStock(long id, Product obj);
        bool AddStock(long id, Product obj);
    }
}
