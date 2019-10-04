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
            throw new NotImplementedException();
        }

        public Categorie GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Categorie obj)
        {
            throw new NotImplementedException();

            //try
            //{
            //    string sql = "INSERT (Naam) VALUES (@naam) ";

            //    List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
            //    {
            //        new KeyValuePair<string, string>("naam", obj.Naam),
            //    };
            //    DataSet results = ExecuteSql(sql, parameters);
            //    Categorie c = DataSetParser.DataSetToCategorie(results, 0);
            //    ExecuteSql(sql, parameters);

            //    return true;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        public bool Update(Categorie obj)
        {
            throw new NotImplementedException();
        }
    }
}
