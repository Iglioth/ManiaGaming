using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class ICategorieTest : ICategorieContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Categorie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Categorie GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Categorie obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categorie obj)
        {
            throw new NotImplementedException();
        }
    }
}
