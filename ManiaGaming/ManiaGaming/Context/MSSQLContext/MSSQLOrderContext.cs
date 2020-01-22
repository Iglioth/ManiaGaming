using System;
using System.Collections.Generic;
using ManiaGaming.Models.Data;
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
                string sql = "SELECT o.OrderID, o.Datum, o.OntvangerId, o.WerknemerID, o.Ontvangen, o.Aantal, o.ProductID, o.VerzenderID, o.Verzonden FROM [Order] AS o where Ontvangen = 0";

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
                string sql = "SELECT o.OrderID, o.Datum, o.OntvangerId, o.WerknemerID, o.Ontvangen, o.Aantal, o.ProductID, o.VerzenderID, o.Verzonden FROM [Order] WHERE OrderID = @OrderID";
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


                string sql = "INSERT INTO[Order](Datum, OntvangerId, WerknemerID, Ontvangen, Aantal, ProductID, Verzonden, VerzenderID) VALUES (@Datum, @VerzenderID, @OntvangerID, @WerknemerID, 0, @Aantal, @ProductID, 0, @VerzenderID) SELECT SCOPE_IDENTITY() ";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString("yyyy-MM-dd H:mm:ss")),
                    new KeyValuePair<string, string>("OntvangerID", obj.OntvangerID.ToString()),
                    new KeyValuePair<string, string>("WerknemerID", obj.WerknemerID.ToString()),
                    new KeyValuePair<string, string>("Aantal", obj.Aantal.ToString()),
                    new KeyValuePair<string, string>("ProductID", obj.ProductID.ToString()),
                    new KeyValuePair<string, string>("VerzenderID", obj.VerzenderID.ToString())
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
