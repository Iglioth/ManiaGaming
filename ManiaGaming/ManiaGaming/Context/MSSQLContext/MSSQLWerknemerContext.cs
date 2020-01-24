using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using ManiaGaming.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

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
                string sql = "SELECT A.AccountId, A.Naam, A.Achternaam, A.Email, F.Stad, Werknemer.FiliaalId, Werknemer.WerknemerId FROM Account AS A INNER JOIN Werknemer on A.Accountid = Werknemer.AccountID " +
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
                string sql = "SELECT A.AccountId, A.Naam, A.Achternaam, A.Email, F.Stad, Werknemer.FiliaalId, Werknemer.WerknemerId FROM Account AS a INNER JOIN Werknemer on A.Accountid = Werknemer.AccountID " +
                "INNER JOIN Filiaal AS F on Werknemer.FiliaalId = F.FiliaalId WHERE A.AccountID = @WerknemerID";
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

        public int GetWerknemerID(long id)
        {
            try
            {
                string sql = "SELECT WerknemerID FROM Werknemer WHERE AccountID = @AccountID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("AccountID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                int werknemerid = (int)results.Tables[0].Rows[0][0];
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
                    new KeyValuePair<string, string>("password", "AQAAAAEAACcQAAAAEPPM9G/VYE4sVxaIJ8PTaOvnhNlR/t15rjfGWMvTEgR2PJIVs+1uCkYuQQOMx4nKDQ=="),
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
                string sql = "UPDATE Werknemer SET FiliaalID = @FiliaalID WHERE AccountId = @WerknemerId";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("FiliaalID", obj.FiliaalID.ToString()),
                    new KeyValuePair<string, string>("WerknemerId", obj.Id.ToString())
                };

                ExecuteSql(sql, parameters);

                sql = "UPDATE Account SET Naam = @Naam, AchterNaam = @AchterNaam, Email = @Email WHERE AccountID = @AccountId";
                parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Naam", obj.Naam),
                    new KeyValuePair<string, string>("AchterNaam", obj.AchterNaam),
                    new KeyValuePair<string, string>("Email", obj.Email),
                    new KeyValuePair<string, string>("AccountId", obj.Id.ToString()),
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
