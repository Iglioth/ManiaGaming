using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class CategorieTestContext : ICategorieContext
    {
        public bool Actief(long id, bool actief)
        {
            if (id == 1 && id != 0)
                return true;
            
            else
                return false;
        }

        public List<Categorie> GetAll()
        {
            List<Categorie> TestListCategorie = new List<Categorie>();

            TestListCategorie.Add(new Categorie() { Id = 1, Actief = false, Naam = null });

            return TestListCategorie;
        }

        public Categorie GetById(long id)
        {
            if (id != 0)
            {
                return new Categorie()
                {
                    Id = 1,
                    Naam = "TestNaam",
                    Actief = true
                };
            }
            else
            {
                return null;
            }
        }

        public long Insert(Categorie obj)
        {
            if(obj.Id == 1)
            {
                return 1;
            }
            return 0;
        }

        public bool Update(Categorie obj)
        {
            throw new NotImplementedException();
        }
    }
}
