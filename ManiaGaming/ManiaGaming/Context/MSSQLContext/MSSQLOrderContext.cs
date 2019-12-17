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
                
                string sql = "UPDATE [Order] SET Ontvangen = 1 WHERE OrderID = @id";

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
                string sql = "SELECT * FROM [Order] where Ontvangen = 0";

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
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("OrderID", id.ToString())
                };

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


                string sql = "INSERT INTO[Order](Datum, FiliaalID, WerknemerID, Ontvangen, Aantal, ProductID) VALUES (@Datum,@FiliaalID,@WerknemerID,@Ontvangen,@Aantal,@ProductID) SELECT SCOPE_IDENTITY() ";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString("yyyy-MM-dd H:mm:ss")),
                    new KeyValuePair<string, string>("FiliaalID", obj.FiliaalID.ToString()),
                    new KeyValuePair<string, string>("WerknemerID", obj.WerknemerID.ToString()),
                    new KeyValuePair<string, string>("Ontvangen", obj.Ontvangen.ToString()),
                    new KeyValuePair<string, string>("Aantal", obj.Aantal.ToString()),
                    new KeyValuePair<string, string>("ProductID", obj.ProductID.ToString())
                };
               
                DataSet results = ExecuteSql(sql, parameters);
                obj.Id = (int)(decimal)results.Tables[0].Rows[0][0];

                string query = "INSERT INTO ProductOrder (OrderID,ProductID,aantal) VALUES (@OrderID,@ProductID,@aantal); ";
                List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>
                {
                    
                    
                    new KeyValuePair<string, string>("OrderID", obj.Id.ToString()),
                    new KeyValuePair<string, string>("ProductID", obj.ProductID.ToString()),
                    new KeyValuePair<string, string>("aantal", obj.Aantal.ToString())
                    
                };
                ExecuteSql(query, Parameters);
                long OrderID;
                OrderID = (long)obj.Id;
                return OrderID;
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
                string sql = "UPDATE [Order] SET Datum = @Datum   where OrderID = @OrderID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("OrderID",obj.Id.ToString()),
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString()),
                    
                };
                ExecuteInsert(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
