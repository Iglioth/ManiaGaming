using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class WerknemerRepository
    {
        protected IWerknemerContext context;

        public WerknemerRepository(IWerknemerContext context)
        {
            this.context = context ?? throw new NullReferenceException("De WerknemerContext is leeg!");
        }

       public List<Werknemer> GetAll()
        {
            return context.GetAll();
        }

        public Werknemer GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Werknemer obj)
        {
            return Insert(obj);
        }
       public bool Update(Werknemer obj)
        {
            return context.Update(obj);
        }

        public bool Actief(long id, bool active)
        {
            return context.Actief(id, active);
        }
        public int GetWerknemerID(long id)
        {
            return context.GetWerknemerID(id);
        }
    }
}
