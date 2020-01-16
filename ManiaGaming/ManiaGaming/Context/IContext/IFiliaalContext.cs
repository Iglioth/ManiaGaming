using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.IContext
{
    public interface IFiliaalContext : IGenericQueries<Filiaal>
    {
        void Delete(Filiaal filiaal);
    }
}
