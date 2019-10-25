﻿using System;
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

        public bool Actief(Categorie obj, long id)
        {
            try
            {
                string sql = "UPDATE Categorie SET Actief = @actief WHERE CategorieID = @categorieID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Actief", obj.Actief.ToString()),
                    new KeyValuePair<string, string>("ProductID", obj.CategorieId.ToString())
                };
                ExecuteSql(sql, parameters);

                return obj.Actief;

            }
            catch (Exception e)
            {
                throw e;
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
                string sql = "UPDATE Categorie SET Naam = @naam WHERE CategorieId = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("id", Convert.ToString(obj.CategorieId)),
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
