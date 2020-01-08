using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.IContext
{
    public interface IWerknemerContext : IGenericQueries<Werknemer>
    {
        int GetWerknemerID(long id);
    }
}
