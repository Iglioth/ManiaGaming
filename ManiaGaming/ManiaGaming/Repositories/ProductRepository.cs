﻿using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

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
        public bool VeranderStock(long id, Product obj)
        {
            return context.VeranderStock(id, obj);
        }

        public bool Actief(long id, bool active)
        {
            return context.Actief(id, active);
        }
        public bool UpdateVoorraad(int id, int aantal)
        {
             return context.UpdateVoorraad(id,aantal);
        }
        public List<Product> GetAllGames()
        {
            return context.GetAllGames();
        }
        public List<Product> GetAllAccesoires()
        {
            return context.GetAllAccesoires();
        }
        public List<Product> GetAllMerchandise()
        {
            return context.GetAllMerchandise();
        }

        public List<Product> GetAllConsole()
        {
            return context.GetAllConsole();
        }

        public List<Product> Zoeken(string zoekterm)
        {
            return context.Zoeken(zoekterm);
        }
    }
}
