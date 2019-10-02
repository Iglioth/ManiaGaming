using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using ManiaGaming.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLWerknemerContext : BaseMSSQLContext, IWerknemerContext
    {
        public MSSQLWerknemerContext(IConfiguration config) : base(config)
        {
        }

        public List<Werknemer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Werknemer GetById(long id)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Werknemer WHERE werknemerID = @werknemerID";
            parameters.Add(new KeyValuePair<string, string>("werknemerID", id.ToString()));
            DataSet dataset = ExecuteSql(query, parameters);
            Werknemer werknemer = DataSetParser.DataSetToWerknemer(dataset, RowNummer);

            return werknemer;
        }

        public long Insert(Werknemer obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Werknemer obj)
        {
            Werknemer werknemer = new Werknemer();
            try
            {
                string sql = "UPDATE (Naam, Achternaam, Functie) VALUES(@naam, @achternaam, @functie) ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", werknemer.Naam),
                    new KeyValuePair<string, string>("achternaam", werknemer.AchterNaam),
                    new KeyValuePair<string, string>("functie", werknemer.Functie),
                    
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
