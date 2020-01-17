using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using ManiaGaming.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

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
                string sql = "SELECT Product.ProductID , Product.CategorieId, Product.Omschrijving,Product.naam,Product.Aantal, Product.Prijs, Product.Soort,Product.Actief,Product.Tweedehands,Categorie.Naam, Product.ImagePath FROM Product INNER JOIN Categorie ON Product.CategorieID = Categorie.CategorieID ";

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

        public List<Product> GetAllGames()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "select Product.ProductID , Product.CategorieId, Product.Omschrijving,Product.naam,Product.Aantal, Product.Prijs, Product.Soort,Product.Actief,Product.Tweedehands,Product.Naam, Product.ImagePath from Product where CategorieId <= 9";

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

        public List<Product> GetAllAccesoires()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "Select Product.ProductID , Product.CategorieId, Product.Omschrijving,Product.naam,Product.Aantal, Product.Prijs, Product.Soort,Product.Actief,Product.Tweedehands,Product.Naam, Product.ImagePath from Product where CategorieId = 14 ";

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
        

              public List<Product> GetAllConsole()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "Select Product.ProductID , Product.CategorieId, Product.Omschrijving,Product.naam,Product.Aantal, Product.Prijs, Product.Soort,Product.Actief,Product.Tweedehands,Product.Naam, Product.ImagePath from Product where CategorieId = 11 ";

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

        public List<Product> GetAllMerchandise()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "Select Product.ProductID , Product.CategorieId, Product.Omschrijving,Product.naam,Product.Aantal, Product.Prijs, Product.Soort,Product.Actief,Product.Tweedehands,Product.Naam, Product.ImagePath from Product where CategorieId = 13";

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
                string sql = "SELECT Product.ProductID , Product.CategorieId, Product.Omschrijving,Product.naam,Product.Aantal, Product.Prijs, Product.Soort,Product.Actief,Product.Tweedehands,Categorie.Naam, Product.ImagePath FROM Product INNER JOIN Categorie ON Product.CategorieID = Categorie.CategorieID WHERE ProductID =  @productID";

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
                string sql = "INSERT INTO Product(Aantal, Naam, Soort, CategorieId, Omschrijving, Prijs, Tweedehands, Actief, ImagePath) OUTPUT INSERTED.ProductId VALUES(0, @naam, @soort, @categorieId, @omschrijving, @prijs, @tweedehands, 1, @ImagePath)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("soort", obj.Soort),
                    new KeyValuePair<string, string>("CategorieId", obj.CategorieId.ToString()),
                    new KeyValuePair<string, string>("Omschrijving", obj.Omschrijving),
                    new KeyValuePair<string, string>("Prijs", obj.Prijs.ToString()),
                    new KeyValuePair<string, string>("Tweedehands", obj.Tweedehands.ToString()),
                    new KeyValuePair<string, string>("ImagePath", obj.ImagePath)
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
                string sql = "UPDATE Product SET Naam = @naam, Soort = @soort, CategorieID = @categorieID, Omschrijving = @omschrijving, Prijs = @prijs, ImagePath = @imagepath WHERE Productid = @productID ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("soort", obj.Soort.ToString()),
                    new KeyValuePair<string, string>("categorieID", obj.CategorieId.ToString()),
                    new KeyValuePair<string, string>("omschrijving", obj.Omschrijving),
                    new KeyValuePair<string, string>("prijs", obj.Prijs.ToString()),
                    new KeyValuePair<string, string>("imagepath", obj.ImagePath),
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
        public bool UpdateVoorraad(int id, int aantal)
        {
            try
            {
                //UPDATE Product SET Product.Aantal = (Product.Aantal + 3) where Product.ProductID = 1
                string sql = "UPDATE Product SET Product.Aantal = (Product.Aantal + @aantal) where  Product.ProductID = @Productid";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Productid", id.ToString()),
                    new KeyValuePair<string, string>("aantal", aantal.ToString()),

                };
                ExecuteSql(sql, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Product> Zoeken(string zoekterm)
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "SELECT Product.ProductID , Product.CategorieId, Product.Omschrijving, Product.naam, Product.Aantal, Product.Prijs, Product.Soort, Product.Actief, Product.Tweedehands, Categorie.Naam, Product.ImagePath FROM Product INNER JOIN Categorie ON Product.CategorieID = Categorie.CategorieID WHERE CHARINDEX(@zoekterm, Product.Naam) > 0 ORDER BY Product.Naam";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Zoekterm", zoekterm),
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
    }
}
