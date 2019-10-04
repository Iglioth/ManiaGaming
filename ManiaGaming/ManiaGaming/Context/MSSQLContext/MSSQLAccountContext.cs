using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using System.Data.SqlClient;
using ManiaGaming.Controllers;
using System.Data;
using Microsoft.Extensions.Configuration;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;

namespace ManiaGaming.Context.MSSQLContext
{
    public class AccountMSSQL : BaseMSSQLContext, IAccountContext
    {

        public AccountMSSQL(IConfiguration config) : base(config)
        {
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
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Account WHERE accountID = @accountID";
            parameters.Add(new KeyValuePair<string, string>("accountID", id.ToString()));
            DataSet dataset = ExecuteSql(query, parameters);
            Account account = DataSetParser.DataSetToAccount(dataset, RowNummer);

            return account;
        }

        public long Insert(Account obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account obj)
        {
            try
            {
                string sql = "UPDATE (Naam, Achternaam, Email) VALUES(@Naam, @achternaam, @email) ";
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
