using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class IFiliaalTest : IFiliaalContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public void Delete(Filiaal filiaal)
        {
            throw new NotImplementedException();
        }

        public List<Filiaal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Filiaal GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Filiaal obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Filiaal obj)
        {
            throw new NotImplementedException();
        }
    }
}
