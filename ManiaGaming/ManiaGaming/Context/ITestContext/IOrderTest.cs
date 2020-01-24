using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class IOrderTest : IOrderContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Order obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order obj)
        {
            throw new NotImplementedException();
        }

        public bool Verzenden(long id)
        {
            throw new NotImplementedException();
        }
    }
}
