using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ManiaGaming.Models.Data;
using ManiaGaming.Controllers;
using System.Data;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using Microsoft.Extensions.Configuration;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLOrderContext : BaseMSSQLContext, IOrderContext
    {
        public MSSQLOrderContext(IConfiguration config) : base(config)
        {
        }

        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            List<Order> orderList = new List<Order>();
            try
            {
                string sql = "SELECT datum, werknemerID, filiaalID FROM Order";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {

                }

                DataSet results = ExecuteSql(sql, parameters);

                for(int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Order o = DataSetParser.DataSetToOrder(results, x);
                    orderList.Add(o);
                }
                return orderList;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Order GetById(long id)
        {
            try
            {
                string sql = "SELECT datum, filiaalID, medewerkerID FROM order WHERE orderID = @orderID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                    new KeyValuePair<string, string>("orderID", id.ToString());
                };
                DataSet results = ExecuteSql(sql, parameters);
                Order O = DataSetParser.DataSetToOrder(results, 0);
                return O;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public long Insert(Order obj)
        {
            try
            {
                string sql = "INSERT INTO Order(Datum, werknemerID, filiaalID) VALUES (@Datum, @werknemerID, @filiaalID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString());
                    new KeyValuePair<string, string>("werknemerID", obj.werknemerID.ToString());
                    new KeyValuePair<string, string>("filiaalID", obj.filiaalID.ToString());
                }
                long results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Update(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}
