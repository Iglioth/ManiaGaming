using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using System.Data.SqlClient;
using ManiaGaming.Controllers;
using System.Data;

namespace ManiaGaming.Context.MSSQLContext
{
    public class AccountMSSQL
    {
        public Account getAccount(int accountID)
        {
            Database database = new Database("yo");
            DataSetParser parser = new DataSetParser();

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Account WHERE accountID = @accountID";
            parameters.Add(new KeyValuePair<string, string>("accountID", accountID.ToString()));
            DataSet dataset = database.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToKlant(dataset, RowNummer);

            return klant;
        }
    }
}
