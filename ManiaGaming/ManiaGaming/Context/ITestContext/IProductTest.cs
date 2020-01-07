using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class IProductTest : IProductContext
    {
        public bool Actief(long id, bool actief)
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

        public bool Update(Product obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVoorraad(int id, int aantal)
        {
            throw new NotImplementedException();
        }

        public bool VeranderStock(long id, Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
