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
