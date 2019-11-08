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
    public class MSSQLFiliaalContext : BaseMSSQLContext, IFiliaalContext
    {
        public MSSQLFiliaalContext(IConfiguration config) : base(config)
        {

        }

        public bool Actief(long id, bool Actief)
        {
            throw new NotImplementedException();
        }

        public List<Filiaal> GetAll()
        {
            try
            {
                string sql = "select * from Filiaal";
                List<Filiaal> lijstfiliaal = new List<Filiaal>();
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                if (results != null && results.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < results.Tables[0].Rows.Count; i++)
                    {
                        Filiaal f = DataSetParser.DataSetToFiliaal(results, i);
                        lijstfiliaal.Add(f);
                    }
                }
                return lijstfiliaal;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Filiaal GetById(long id)
        {
            try
            {
                string sql = "Select * from Filiaal where FiliaalID = @FiliaalID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                new KeyValuePair<string, string>("FiliaalID", id.ToString())
                };

                DataSet result = ExecuteSql(sql, parameters);

                Filiaal f = DataSetParser.DataSetToFiliaal(result, 0);

                return f;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public long Insert(Filiaal obj)
        {
            try
            {
                string sql = "insert into Filiaal (stad,Huisnummer,Postcode,Telefoonnummer) values (@stad,@Huisnummer,@Postcode,@Telefoonnummer)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("stad",obj.stad),
                    new KeyValuePair<string, string>("Huisnummer",obj.Huisnummer),
                    new KeyValuePair<string, string>("Postcode",obj.Postcode),
                    new KeyValuePair<string, string>("Telefoonnummer",obj.Telefoonnummer.ToString())
                };
                ExecuteSql(sql, parameters);
                return 1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Filiaal obj)
        {
            throw new NotImplementedException();
        }
    }
}
