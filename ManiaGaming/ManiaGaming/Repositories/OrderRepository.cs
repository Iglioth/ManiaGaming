using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class OrderRepository
    {
        protected IOrderContext context;

        public OrderRepository(IOrderContext context)
        {
            this.context = context ?? throw new NullReferenceException("De AccountContext is leeg");
                    
        }

        public List<Order> GetAll()
        {
            return context.GetAll();
        }

        public Order GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Order obj)
        {
            return context.Insert(obj);
        }

        public bool Update(Order obj)
        {
            return context.Update(obj);
        }



    }
}
