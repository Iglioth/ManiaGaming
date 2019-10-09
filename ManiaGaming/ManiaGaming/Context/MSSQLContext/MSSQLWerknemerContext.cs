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
            List<Werknemer> werknemerList = new List<Werknemer>();
            try
            {
                string sql = "SELECT Functie, FiliaalID FROM Werknemer";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Werknemer w = DataSetParser.DataSetToWerknemer(results, x);
                    werknemerList.Add(w);
                }
                return werknemerList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Werknemer GetById(long id)
        {
            try
            {
                string sql = "SELECT Functie, FiliaalID FROM Werknemer WHERE WerknemerID = @WerknemerID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("WerknemerID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                Werknemer w = DataSetParser.DataSetToWerknemer(results, 0);
                return w;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public long Insert(Werknemer obj)
        {
            try
            {
                string sql = "INSERT (Functie, FiliaalID) VALUES(@functie, @FiliaalID)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Functie", obj.Functie),
                    new KeyValuePair<string, string>("FiliaalID", obj.filiaalID.ToString())
                };
                long result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Update(Werknemer obj)
        {
            Werknemer werknemer = new Werknemer();
            try
            {
                string sql = "UPDATE (Functie, FiliaalID) VALUES(@functie, @FiliaalID) ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Functie", obj.Functie),
                    new KeyValuePair<string, string>("FiliaalID", obj.filiaalID.ToString())
                    
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
