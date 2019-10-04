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

        public bool AddStock(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
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
            /*
            try
            {
                string sql = "INSERT INTO Product(Naam, Prijs, Grootte, Kleur, Beschrijving, Categorie) VALUES(@naam, @prijs, @grootte, @kleur, @beschrijving, @categorie)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", product.Naam),
                    new KeyValuePair<string, string>("prijs", product.Prijs),
                    new KeyValuePair<string, string>("grootte", product.Grootte),
                    new KeyValuePair<string, string>("kleur", product.Kleur),
                    new KeyValuePair<string, string>("beschrijving", product.Beschrijving),
                    new KeyValuePair<string, string>("categorie", product.Categorie)
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            */
            throw new NotImplementedException();
        }

        public bool RemoveStock(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
