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
    public class MSSQLCategorieContext : BaseMSSQLContext, ICategorieContext
    { 
        public MSSQLCategorieContext(IConfiguration config) : base(config)
        {
            
        }

        public List<Categorie> GetAll()
        {
            List<Categorie> categorieList = new List<Categorie>();
            try
            {
                string sql = "SELECT Naam FROM Categorie";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Categorie c = DataSetParser.DataSetToCategorie(results, x);
                    categorieList.Add(c);
                }
                return categorieList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Categorie GetById(long id)
        {
            try
            {
                string sql = "SELECT Naam FROM Categorie WHERE CategorieId = @categorieId";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("categorieId", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Categorie c = DataSetParser.DataSetToCategorie(results, 0);
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Categorie obj)
        {
            try
            {
                string sql = "INSERT INTO Categorie (Naam) VALUES (@naam) ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                };
                ExecuteSql(sql, parameters);
                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Categorie obj)
        {
            try
            {
                string sql = "UPDATE Categorie SET Naam = @Naam";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Naam", obj.Naam),
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
