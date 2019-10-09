﻿using ManiaGaming.Context.IContext;
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

        public bool AddStock(long id, Product obj)
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

        public List<Product> GetAll()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string sql = "SELECT Aantal, Naam, Soort, Categorie, Omschrijving, Prijs FROM Product";

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
                string sql = "SELECT Omschrijving, Naam, Aantal, Prijs, CategorieID FROM Product INNER JOIN Categorie ON product.CategorieID = categorie.CategorieID WHERE ProductID = @productID";

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
                string sql = "INSERT INTO Product(Aantal, Naam, Soort, Categorie, Omschrijving, Prijs) VALUES(@aantal, @naam, @soort, @categorie, @omschrijving, @prijs)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("aantal", obj.Aantal.ToString()),
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("soort", obj.Soort),
                    new KeyValuePair<string, string>("Categorie", obj.Categorie.ToString()),
                    new KeyValuePair<string, string>("Omschrijving", obj.Omschrijving),
                    new KeyValuePair<string, string>("Prijs", obj.Prijs.ToString())
                };

                long results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoveStock(long id, Product obj)
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
            catch(Exception e)
            {
                throw e;
            }

        }

        public bool Update(Product obj)
        {
            try
            {
                string sql = "UPDATE Product SET aantal = @aantal, naam = @naam, soort = @soort, categorie = @categorie, omschrijving = @omschrijving, prijs = @prijs ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("aantal", obj.Aantal.ToString()),
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("soort", obj.Soort),
                    new KeyValuePair<string, string>("categorie", obj.Categorie.ToString()),
                    new KeyValuePair<string, string>("omschrijving", obj.Omschrijving),
                    new KeyValuePair<string, string>("prijs", obj.Prijs.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
