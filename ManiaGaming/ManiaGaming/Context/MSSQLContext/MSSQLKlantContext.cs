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
            throw new NotImplementedException();
        }

        public Klant GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Klant getKlant(int klantID)
        {
            Klant klant = new Klant();
             try
            {
                string sql = "SELECT Naam, Achternaam, Email, Postcode, Huisnummer, Geboortedatum, Punten, AccountID FROM Klant INNER JOIN Account ON klant.klantID = account.AccountID WHERE klantID = @klantID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("klantID", klantID.ToString()),
                };

                ExecuteSql(sql, parameters);

                return klant;
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
            Klant klant = new Klant();
            try
            {
                string sql = "UPDATE (Naam, Achternaam, Email, Postcode, Huisnummer, Geboortedatum) VALUES(@naam, @achternaam, @email, @postcode, @huisnummer, @geboortedatum) ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", klant.Naam),
                    new KeyValuePair<string, string>("achternaam", klant.AchterNaam),
                    new KeyValuePair<string, string>("email", klant.Email),
                    new KeyValuePair<string, string>("postcode", klant.Postcode),
                    new KeyValuePair<string, string>("huisnummer", klant.Huisnummer),
                    new KeyValuePair<string, string>("geboortedatum", klant.Geboortedatum.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*public Klant getAdres(string postCode, string huisNummer)
        {
            Database database = new Database("yo");
            DataSetParser parser = new DataSetParser();

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Klant WHERE postCode = @Postcode, huisNummer = @Huisnummer";
            parameters.Add(new KeyValuePair<string, string>("postCode", postCode.ToString()));
            parameters.Add(new KeyValuePair<string, string>("huisNumm   er", huisNummer.ToString()));
            DataSet dataset = database.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToKlant(dataset, RowNummer);

            return klant;
        }

        public Klant getGeboorteDatum(DateTime datum)
        {
            Database database = new Database("yo");
            DataSetParser parser = new DataSetParser();

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Klant WHERE datum = @Geboortedatum";
            parameters.Add(new KeyValuePair<string, string>("datum", datum.ToString()));
            DataSet dataset = database.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToKlant(dataset, RowNummer);

            return klant;
        }

        public Klant getPunten(int punten)
        {
            Database database = new Database("yo");
            DataSetParser parser = new DataSetParser();

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Klant WHERE punten = @Punten";
            parameters.Add(new KeyValuePair<string, string>("punten", punten.ToString()));
            DataSet dataset = database.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToKlant(dataset, RowNummer);

            return klant;
        }*/
    }
}
