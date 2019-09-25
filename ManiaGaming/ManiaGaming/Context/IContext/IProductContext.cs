using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.IContext
{
    public interface IProductContext
    {
        List<Product> GetProducts();

        bool UpdateProduct();
    }
}
