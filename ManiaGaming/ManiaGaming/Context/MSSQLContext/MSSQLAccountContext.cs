using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using System.Data.SqlClient;
using ManiaGaming.Controllers;
using System.Data;
<<<<<<< HEAD:ManiaGaming/ManiaGaming/Context/MSSQLContext/AccountMSSQL.cs
=======
using Microsoft.Extensions.Configuration;
using ManiaGaming.Context.IContext;
>>>>>>> master:ManiaGaming/ManiaGaming/Context/MSSQLContext/MSSQLAccountContext.cs
using ManiaGaming.Context.Parsers;

namespace ManiaGaming.Context.MSSQLContext
{
    public class AccountMSSQL : BaseMSSQLContext, IAccountContext
    {

        public AccountMSSQL(IConfiguration config) : base(config)
        {
<<<<<<< HEAD:ManiaGaming/ManiaGaming/Context/MSSQLContext/AccountMSSQL.cs
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Account WHERE accountID = @accountID";
            parameters.Add(new KeyValuePair<string, string>("accountID", accountID.ToString()));
            DataSet dataset = BaseMSSQLContext.ExecuteSql(query, parameters);
            Klant klant = DataSetParser.DataSetToAccount(dataset, RowNummer);
=======

        }

        public List<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(long id)
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            int RowNummer = 0;
            string query = "SELECT * FROM Account WHERE accountID = @accountID";
            parameters.Add(new KeyValuePair<string, string>("accountID", id.ToString()));
            DataSet dataset = ExecuteSql(query, parameters);
            Account account = DataSetParser.DataSetToAccount(dataset, RowNummer);
>>>>>>> master:ManiaGaming/ManiaGaming/Context/MSSQLContext/MSSQLAccountContext.cs

            return account;
        }

        public long Insert(Account obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account obj)
        {
            throw new NotImplementedException();
        }
    }
}
