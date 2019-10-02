using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using System.Data.SqlClient;
using ManiaGaming.Controllers;
using System.Data;
using ManiaGaming.Context.Parsers;

namespace ManiaGaming.Context.MSSQLContext
{
    public class AccountMSSQL
    {
        public Account getAccount(int accountID)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Account WHERE accountID = @accountID";
            parameters.Add(new KeyValuePair<string, string>("accountID", accountID.ToString()));
            DataSet dataset = BaseMSSQLContext.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToAccount(dataset, RowNummer);

            return klant;
        }
    }
}
