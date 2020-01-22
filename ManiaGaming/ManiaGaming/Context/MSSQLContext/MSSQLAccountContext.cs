using System;
using System.Collections.Generic;
using ManiaGaming.Models.Data;
using System.Data;
using Microsoft.Extensions.Configuration;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLAccountContext : BaseMSSQLContext, IAccountContext
    {

        public MSSQLAccountContext(IConfiguration config) : base(config)
        {
        }

        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAll()
        {
            List<Account> accountList = new List<Account>();
            try
            {
                string sql = "SELECT Naam, Achternaam, Email FROM Account";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Account a = DataSetParser.DataSetToAccount(results, x);
                    accountList.Add(a);
                }
                return accountList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Account GetById(long id)
        {
            try
            {
                string sql = "SELECT Email, Naam, Achternaam FROM Account WHERE AccountID = @AccountID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("accountID", id.ToString())
                };

                DataSet results = ExecuteSql(sql, parameters);
                Account a = DataSetParser.DataSetToAccount(results, 0);
                return a;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public long Insert(Account obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account obj)
        {
            try
            {
                string sql = "UPDATE Account SET Naam = @naam, Achternaam = @achternaam, Email = @email";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("achternaam", obj.AchterNaam),
                    new KeyValuePair<string, string>("email", obj.Email.ToString()),
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
