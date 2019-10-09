﻿using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class BestellingRepository
    {
        protected IBestellingContext context;

        public BestellingRepository(IBestellingContext context)
        {
            this.context = context ?? throw new NotImplementedException("IBestellingContext is leeg");
        }

        public List<Bestelling> GetAll()
        {
            return context.GetAll();
        }
        public Bestelling GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Bestelling obj)
        {
            return context.Insert(obj);
        }

        public bool Update(Bestelling obj)
        {
            return context.Update(obj);
        }
    }
}