using System;
using System.Collections.Generic;
using ManiaGaming.Models.Data;
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


        public bool Actief(long id, bool active)
           
        {
            if (active == true)
            {
                string sql = "UPDATE Categorie SET Actief = 0 WHERE id = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            else if (active == false)
            {
                string sql = "UPDATE Categorie SET Actief = 1 WHERE id = @id";

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

        public List<Categorie> GetAll()
        {
            try
            {
                string sql = "SELECT * From Categorie";
                List<Categorie> categorieList = new List<Categorie>();

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                };

                DataSet result = ExecuteSql(sql, parameters);

                if (result != null && result.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < result.Tables[0].Rows.Count; x++)
                    {
                        Categorie c = DataSetParser.DataSetToCategorie(result, x);
                        categorieList.Add(c);
                    }
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
                string sql = "SELECT * FROM Categorie WHERE CategorieId = @categorieId";

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
                string sql = "INSERT INTO Categorie (Naam , Actief) VALUES (@naam , 1) ";

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
                string sql = "UPDATE Categorie SET Naam = @naam WHERE CategorieId = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("id", Convert.ToString(obj.Id)),
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
