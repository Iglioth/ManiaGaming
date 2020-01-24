using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.IContext
{
    public interface IOrderContext : IGenericQueries<Order>
    {
        bool Verzenden(long id);
    }
}
