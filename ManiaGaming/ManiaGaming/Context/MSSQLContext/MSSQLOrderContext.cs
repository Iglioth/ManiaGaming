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
            try
            {
                string sql = "UPDATE Order SET Ontvangen = 1 WHERE productid = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }

            catch
            {
                return false;
            }
        }

       

        
        public List<Order> GetAll()
        {
            List<Order> orderList = new List<Order>();
            try
            {
                string sql = "SELECT * FROM [Order]";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();


                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Order o = DataSetParser.DataSetToOrder(results, x);
                    orderList.Add(o);
                }
                return orderList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Order GetById(long id)
        {
            try
            {
                string sql = "SELECT * FROM [Order] WHERE OrderID = @OrderID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

                parameters.Add(new KeyValuePair<string, string>("OrderID", id.ToString()));

                DataSet results = ExecuteSql(sql, parameters);
                Order O = DataSetParser.DataSetToOrder(results, 0);
                return O;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Order obj)
        {
            try
            {
                string sql = "INSERT INTO [Order](Datum, WerknemerID, FiliaalID) VALUES (@Datum, @werknemerID, @filiaalID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString());
                    new KeyValuePair<string, string>("werknemerID", obj.WerknemerID.ToString());
                    new KeyValuePair<string, string>("filiaalID", obj.FiliaalID.ToString());
                }
                long results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }

        public bool Update(Order obj)
        {
            try
            {
                string sql = "SET(Datum, Werknemer, FiliaalID) Values(@Datum, @werknermerID,@filiaalID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString());
                    new KeyValuePair<string, string>("werknemerID", obj.WerknemerID.ToString());
                    new KeyValuePair<string, string>("filiaalID", obj.FiliaalID.ToString());
                }
                long results = ExecuteInsert(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
