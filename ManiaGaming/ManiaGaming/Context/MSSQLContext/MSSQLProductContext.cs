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

        public bool AddStock(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Product obj)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStock(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
