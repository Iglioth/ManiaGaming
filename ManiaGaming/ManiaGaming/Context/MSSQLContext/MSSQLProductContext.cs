using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLProductContext : BaseMSSQLContext , IProductContext
    {
        public MSSQLProductContext(IConfiguration config) : base(config)
        {
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
