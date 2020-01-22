using ManiaGaming.Interfaces;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.IContext
{
    public interface IKlantContext : IGenericQueries<Klant>
    {
        int GetKlantID(long id);
        void UpdateKlantPunten(int punten, int id);
    }
}
