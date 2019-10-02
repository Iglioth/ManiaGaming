using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ManiaGaming.Models.Data;
using ManiaGaming.Controllers;
using System.Data;

namespace ManiaGaming.Context.MSSQLContext
{
    public class klantMSSQL
    {
        public Klant getKlant(int klantID)
        {
            Database database = new Database("yo");
            DataSetParser parser = new DataSetParser();
            
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT Naam, Achternaam, Email, Postcode, Huisnummer, Geboortedatum, Punten, AccountID FROM Klant WHERE klantID = @klantID";
            parameters.Add(new KeyValuePair<string, string>("klantID", klantID.ToString()));
            DataSet dataset = database.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToKlant(dataset, RowNummer);
            
            return klant;
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
