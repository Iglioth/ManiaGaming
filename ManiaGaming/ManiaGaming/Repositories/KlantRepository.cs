using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class KlantRepository
    {

        protected readonly IKlantContext context;

        public KlantRepository(IKlantContext context)
        {
            this.context = context ?? throw new NullReferenceException("De KlantContext is leeg.");
        }

        public List<Klant> GetAll()
        {
            return context.GetAll();
        }

        public Klant GetById(long id)
        {
            return context.GetById(id);
        }

       public bool Update(Klant obj)
        {
            return context.Update(obj);
        }
        public int GetKlantID(long id)
        {
            return context.GetKlantID(id);
        }




    }
}
