﻿using System;
using System.Collections.Generic;
using ManiaGaming.Models.Data;
using ManiaGaming.Context.IContext;
using ManiaGaming.Context.Parsers;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ManiaGaming.Context.MSSQLContext
{
    public class MSSQLBestellingContext : BaseMSSQLContext, IBestellingContext
    {
        public MSSQLBestellingContext(IConfiguration config) : base(config)
        {

        }

        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Bestelling> GetAll()
        {
            List<Bestelling> bestellingList = new List<Bestelling>();
            try
            {
                string sql = "SELECT Datum, KlantID FROM Bestelling";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {

                };

                DataSet results = ExecuteSql(sql, parameters);

                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    Bestelling b = DataSetParser.DataSetToBestelling(results, x);
                    bestellingList.Add(b);
                }
                return bestellingList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Bestelling GetById(long id)
        {
            try
            {
                string sql = "SELECT Datum, KlantID FROM Bestelling WHERE bestellingID = @bestellingID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("bestellingID", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Bestelling b = DataSetParser.DataSetToBestelling(results, 0);
                return b;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Bestelling obj)
        {
            try
            {
                string sql = "INSERT INTO Order(Datum, klantID) VALUES (@Datum, @klantID)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                    new KeyValuePair<string, string>("Datum", obj.Datum.ToString());
                    new KeyValuePair<string, string>("klantID", obj.Id.ToString());
                }
                long results = ExecuteInsert(sql, parameters);
                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Bestellen(List<Product> Producten,long KlantID)
        {
            try
            {
                Bestelling bestelling = new Bestelling();
                bestelling.Datum = DateTime.Now;

                string sql = "INSERT INTO Bestelling (Datum,KlantID) values (@Datum,@KlantID) SELECT Scope_Identity()";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
                {
                        parameters.Add(new KeyValuePair<string, string>("Datum", bestelling.Datum.ToString("yyyy-MM-dd H:mm:ss")));
                        parameters.Add(new KeyValuePair<string, string>("KlantID", KlantID.ToString()));
                };
                DataSet results = ExecuteSql(sql, parameters);
                bestelling.Id = (int)(decimal)results.Tables[0].Rows[0][0];

                if(Producten != null)
                {
                    foreach (Product p in Producten)
                    {

                        string query = "INSERT INTO ProductBestelling (BestellingID,ProductID,aantal) values (@bestellingId,@productId ,@aantal)  ";
                        List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("bestellingId",bestelling.Id.ToString()),
                                new KeyValuePair<string, string>("productId",p.Id.ToString()),
                                new KeyValuePair<string, string>("aantal",p.Aantal.ToString())
                            };

                        ExecuteSql(query, Parameters);
                    }
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool Update(Bestelling obj)
        {
            throw new NotImplementedException();
        }

        public List<BestellingProduct> GetAllById(long id)
        {
            List<BestellingProduct> BestelList = new List<BestellingProduct>();
            try
            {
                string sql = "SELECT Product.Naam, Product.Omschrijving, ProductBestelling.aantal, Product.Prijs, Bestelling.Datum FROM ((ProductBestelling INNER JOIN Product ON ProductBestelling.ProductId = Product.ProductId) INNER JOIN Bestelling ON ProductBestelling.BestellingID = Bestelling.BestellingID) WHERE KlantID = @klantID";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("klantID", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    BestellingProduct p = DataSetParser.DataSetToBestellingProduct(results, x);
                    BestelList.Add(p);
                }
                return BestelList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
