using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class FiliaalRepository : IFiliaalContext
    {
        IFiliaalContext context;

        public FiliaalRepository(IFiliaalContext context)
        {
            this.context = context;
        }


        public bool Actief(long id, bool Actief)
        {
            return context.Actief(id, Actief);
        }

        public List<Filiaal> GetAll()
        {
            return context.GetAll();
        }

        public Filiaal GetById(long id)
        {
            return context.GetById(id);
        }

        public long Insert(Filiaal obj)
        {
            return context.Insert(obj);
        }

        public bool Update(Filiaal obj)
        {
            return context.Update(obj);
        }

    }
}
