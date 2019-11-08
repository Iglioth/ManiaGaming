using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using ManiaGaming.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLProductContext : BaseMSSQLContext , IProductContext
    {
        public MSSQLProductContext(IConfiguration config) : base(config)
        {
        }

        public bool Actief(long id, bool active)
        {
            if (active == true)
            {
                string sql = "UPDATE Product SET Actief = 0 WHERE productid = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            else if (active == false)
            {
                string sql = "UPDATE Product SET Actief = 1 WHERE productid = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            else
            {
                return false;
            }
        }


        public List<Product> GetAll()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "SELECT * FROM Product";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Product p = DataSetParser.DataSetToProduct(results, x);
                    productList.Add(p);
                }
                return productList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product GetById(long id)
        {
            try
            {
                string sql = "SELECT * FROM Product INNER JOIN Categorie ON product.CategorieID = categorie.CategorieID WHERE ProductID = @productID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("productID", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Product p = DataSetParser.DataSetToProduct(results, 0);
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Product obj)
        {
            
            try
            {
                string sql = "INSERT INTO Product(Aantal, Naam, Soort, CategorieId, Omschrijving, Prijs) OUTPUT INSERTED.ProductId VALUES(0, @naam, @soort, @categorieId, @omschrijving, @prijs)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("soort", obj.Soort),
                    new KeyValuePair<string, string>("CategorieId", obj.CategorieId.ToString()),
                    new KeyValuePair<string, string>("Omschrijving", obj.Omschrijving),
                    new KeyValuePair<string, string>("Prijs", obj.Prijs)
                };

                int result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Product obj)
        {
            try
            {
                string sql = "UPDATE Product SET Naam = @naam, Soort = @soort, CategorieID = @categorieID, Omschrijving = @omschrijving, Prijs = @prijs WHERE Productid = @productID ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("soort", obj.Soort.ToString()),
                    new KeyValuePair<string, string>("categorieID", obj.CategorieId.ToString()),
                    new KeyValuePair<string, string>("omschrijving", obj.Omschrijving),
                    new KeyValuePair<string, string>("prijs", obj.Prijs.ToString()),
                    new KeyValuePair<string, string>("productID", obj.Id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        public bool VeranderStock(long id, Product obj)
        {
            try
            {
                string sql = "UPDATE Product SET Aantal = @aantal WHERE productid = @productid";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("productid", id.ToString()),
                    new KeyValuePair<string, string>("aantal", obj.Aantal.ToString())
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
