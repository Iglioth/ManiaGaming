using ManiaGaming.Context.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class ProductRepository
    {
        //global instances
        protected readonly IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context ?? throw new NullReferenceException("De commentaarContext is leeg.");
        }
    }
}
