using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLBestellingContext : BaseMSSQLContext, IBestellingContext
    {
        public MSSQLBestellingContext(IConfiguration config) : base(config)
        {

        }

        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Bestelling> GetAll()
        {
            List<Bestelling> bestellingList = new List<Bestelling>();
            try
            {
                string sql = "SELECT Datum, KlantID FROM Bestelling";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Bestelling b = DataSetParser.DataSetToBestelling(results, x);
                    bestellingList.Add(b);
                }
                return bestellingList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Bestelling GetById(long id)
        {
            try
            {
                string sql = "SELECT Datum, KlantID FROM Bestelling WHERE bestellingID = @bestellingID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("bestellingID", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Bestelling b = DataSetParser.DataSetToBestelling(results, 0);
                return b;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Bestelling obj)
        {
            try
            {
                string sql = "INSERT INTO Order(Datum, klantID) VALUES (@Datum, @klantID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString());
                    new KeyValuePair<string, string>("klantID", obj.klantID.ToString());
                }
                long results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Bestelling obj)
        {
            throw new NotImplementedException();
        }
    }
}
