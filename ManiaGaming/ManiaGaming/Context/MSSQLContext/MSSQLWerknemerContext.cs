using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using ManiaGaming.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLWerknemerContext : BaseMSSQLContext, IWerknemerContext
    {
        public MSSQLWerknemerContext(IConfiguration config) : base(config)
        {
        }

        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Werknemer> GetAll()
        {
            List<Werknemer> werknemerList = new List<Werknemer>();
            try
            {
                string sql = "SELECT A.AccountId, A.Naam, A.Achternaam, A.Email, F.Stad FROM Account AS A INNER JOIN Werknemer on A.Accountid = Werknemer.AccountID " +
                "INNER JOIN Filiaal AS F on Werknemer.FiliaalId = f.FiliaalId ";

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
                string sql = "SELECT A.AccountId, A.Naam, A.Achternaam, A.Email, F.Stad FROM Account AS a INNER JOIN Werknemer on Account.id = Werknemer.AccountID " +
                "INNER JOIN Filiaal AS F on Werknemer.FiliaalId = Filiaal.Id ";
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
                throw e;
            }
        }

        public int  GetWerknemerID(long id)
        {
            try
            {
                string sql = "SELECT WerknemerID FROM Werknemer WHERE AccountID = @AccountID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("AccountID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                int werknemerid = (int)(decimal)results.Tables[0].Rows[0][0];
                return werknemerid;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Werknemer obj)
        {
            try
            {
                string query = "exec InsertWerknemer " +
                               "@Naam = @naam, " +
                               "@Achternaam = @achternaam, " +
                               "@Password = @password, " +
                               "@Email = @email, " +
                               "@filiaalid = @filiaalid";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("achternaam", obj.AchterNaam),
                    new KeyValuePair<string, string>("email", obj.Email),
                    new KeyValuePair<string, string>("password", obj.Password),
                    new KeyValuePair<string, string>("filiaalid", obj.FiliaalID.ToString()),
                };
                ExecuteSql(query, parameters);
                long result = 1;
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Werknemer obj)
        {
            Werknemer werknemer = new Werknemer();
            try
            {
                string sql = "UPDATE Werknemer SET Functie = @Functie, FiliaalID = @FiliaalID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Functie", obj.Functie),
                    new KeyValuePair<string, string>("FiliaalID", obj.FiliaalID.ToString())
                    
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
