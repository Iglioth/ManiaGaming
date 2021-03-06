﻿using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Repositories
{
    public class CategorieRepository
    {
        protected ICategorieContext context;

        public CategorieRepository(ICategorieContext context)
        {
            this.context = context ?? throw new NullReferenceException("De CategorieContext is leeg. ");
        }

        public List<Categorie> GetAll()
        {
            return context.GetAll();
        }
        public Categorie GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Categorie obj)
        {
            return context.Insert(obj);
        }

        public bool Update(Categorie obj)
        {
            return context.Update(obj);
        }

        public bool Actief(long id, bool active)
        {
            return context.Actief(id, active);
        }
    }
}
