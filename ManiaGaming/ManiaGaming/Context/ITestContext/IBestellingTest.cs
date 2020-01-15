using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.ITestContext
{
    public class IBestellingTest : IBestellingContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public bool Bestellen(List<Product> Producten, long KlantID)
        {
            if (KlantID != 0)
            {
                foreach(Product TestProduct in Producten)
                {
                    if(TestProduct.Id == 0 || TestProduct.Naam == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public List<Bestelling> GetAll()
        {
            List<Bestelling> ListTestBestelling = new List<Bestelling>();
            ListTestBestelling.Add(new Bestelling()
            {
                Id = 1212,
                Actief = false,
                KlantID = 2
            });

            return ListTestBestelling;
        }

        public List<BestellingProduct> GetAllById(long id)
        {
            throw new NotImplementedException();
        }

        public Bestelling GetById(long id)
        {
            if (id > 0 && id != 0)
            {
                return new Bestelling()
                {
                    Id = 1212,
                    Actief = false,
                    KlantID = 2
                };
            }

            else return null;
        }

        public long Insert(Bestelling obj)
        {
            if(obj.Id != 0 && obj.Id > 0)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }

        public bool Update(Bestelling obj)
        {
            throw new NotImplementedException();
        }
    }
}
