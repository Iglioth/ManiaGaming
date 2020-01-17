using System;
using System.Collections.Generic;
using ManiaGaming.Models.Data;
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

        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
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
                string sql = "SELECT KlantID, Postcode, Huisnummer, Geboortedatum, Punten, Account.AccountID, Email, Naam, Achternaam FROM Klant INNER JOIN Account ON klant.AccountID = Account.AccountID WHERE Account.AccountID = @AccountID;";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("AccountID", id.ToString()),
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

        public int GetKlantID(long id)
        {
            try
            {
                string sql = "Select Klant.KlantID from Account inner join Klant on Account.AccountID = Klant.AccountID where Account.AccountID = @AccountID;";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("AccountID", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                int klantid = (int)results.Tables[0].Rows[0][0];
                return klantid;
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
                string sql = "UPDATE Klant SET Postcode = @postcode, Huisnummer = @huisnummer, Geboortedatum = @geboortedatum";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                { 
                    new KeyValuePair<string, string>("postcode", obj.Postcode),
                    new KeyValuePair<string, string>("huisnummer", obj.Huisnummer),
                    new KeyValuePair<string, string>("geboortedatum", obj.Geboortedatum.ToString("yyyy/M/dd")),
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
