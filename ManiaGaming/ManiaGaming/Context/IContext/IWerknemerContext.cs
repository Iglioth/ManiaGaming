using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.IContext
{
    public interface IWerknemerContext : IGenericQueries<Werknemer>
    {
        int GetWerknemerID(long id);
    }
}
