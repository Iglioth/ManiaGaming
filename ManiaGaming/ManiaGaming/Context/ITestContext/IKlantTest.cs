using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class IKlantTest : IKlantContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Klant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Klant GetById(long id)
        {
            throw new NotImplementedException();
        }

        public int GetKlantID(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Klant obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Klant obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateKlantPunten(int punten, int id)
        {
            throw new NotImplementedException();
        }
    }
}
