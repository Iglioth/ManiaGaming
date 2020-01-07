using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.ITestContext
{
    public class IWerknemerTest : IWerknemerContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Werknemer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Werknemer GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Werknemer obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Werknemer obj)
        {
            throw new NotImplementedException();
        }
    }
}
