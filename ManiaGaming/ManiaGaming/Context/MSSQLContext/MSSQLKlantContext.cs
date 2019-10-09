using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ManiaGaming.Models.Data;
using ManiaGaming.Controllers;
using System.Data;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using Microsoft.Extensions.Configuration;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLKlantContext : BaseMSSQLContext , IKlantContext
    {
        public MSSQLKlantContext(IConfiguration config) : base(config)
        {

        }

        public List<Klant> GetAll()
        {
            List<Klant> klantList = new List<Klant>();
            try
            {
                string sql = "SELECT Naam, Achternaam, Email, Postcode, Huisnummer, Geboortedatum, Punten, AccountID FROM Klant INNER JOIN Account ON klant.klantID = account.AccountID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Klant k = DataSetParser.DataSetToKlant(results, x);
                    klantList.Add(k);
                }
                return klantList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Klant GetById(long id)
        {
             try
            {
                string sql = "SELECT Naam, Achternaam, Email, Postcode, Huisnummer, Geboortedatum, Punten, AccountID FROM Klant INNER JOIN Account ON klant.klantID = account.AccountID WHERE klantID = @klantID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("klantID", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Klant k = DataSetParser.DataSetToKlant(results, 0);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Klant obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Klant obj)
        {
            try
            {
                string sql = "UPDATE Klant SET Postcode = @postcode, Huisnummer = @huisnummer, Geboordedatum = @geboortedatum";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                { 
                    new KeyValuePair<string, string>("postcode", obj.Postcode),
                    new KeyValuePair<string, string>("huisnummer", obj.Huisnummer),
                    new KeyValuePair<string, string>("geboortedatum", obj.Geboortedatum.ToString()),
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
