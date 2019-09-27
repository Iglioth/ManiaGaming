using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ManiaGaming.Models.Data;
using ManiaGaming.Controllers;

namespace ManiaGaming.Context.MSSQLContext
{
    public class klantMSSQL
    {
        public Klant getKlant(int klantID)
        {
            Database database = new Database("yo");
            DataSetParser parser = new DataSetParser();
            Klant klant = new Klant();
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            string query = "SELECT * FROM Klant WHERE klantID = @klantID";
            //SqlCommand cmd = new SqlCommand(query, conn);
            //cmd.Parameters.AddWithValue("@klantID", klantID);
            parameters.Add(new KeyValuePair<string, string>("klantID", klantID.ToString()));
            /* using (SqlDataReader reader = cmd.ExecuteReader())
             {
                 reader.Read();

                 klant = new Klant(reader["ID"].ToString());
             }*/

            //klant = new Klant(parser.DataSetToKlant(database.ExecuteSql(query, parameters);

            return klant;
        }
    }
}
