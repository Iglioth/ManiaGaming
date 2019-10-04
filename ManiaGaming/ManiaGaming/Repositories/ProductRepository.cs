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

        public List<Account> GetAll()
        {
            return GetAll();
        }

        public Account GetById(long id)
        {
            return GetById(id);
        }

        long Insert(Product product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Het product is leeg.");
            }
            return context.Insert(product);
        }

        public bool Update(Account obj)
        {
            return Update(obj);
        }






    }
}
