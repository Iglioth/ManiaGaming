﻿using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class ProductRepository
    {
        protected readonly IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context ?? throw new NullReferenceException("De ProductContext is leeg.");
        }

        public List<Product> GetAll()
        {
            return context.GetAll();
        }

        public Product GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Product product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Het product is leeg.");
            }
            return context.Insert(product);
        }

        public bool Update(Product obj)
        {
            return context.Update(obj);
        }
        public bool RemoveStock(long id, Product obj)
        {
            return context.RemoveStock(id, obj);
        }
        public bool AddStock(long id, Product obj)
        {
            return context.AddStock(id, obj);
        }






    }
}
