using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

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

        public bool Bestellen(List<Product> Producten, long KlantID)
        {
            return context.Bestellen(Producten,  KlantID);
        }
        public List<BestellingProduct> GetAllById(long id)
        {
            return context.GetAllById(id);
        }
    }
}
