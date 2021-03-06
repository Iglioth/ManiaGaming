﻿using System;
using System.Data;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Context.Parsers
{
    public class DataSetParser
    {
        public static Klant DataSetToKlant(DataSet set, int rowIndex)
        {
            return new Klant()
            {
                KlantId = (int)set.Tables[0].Rows[rowIndex][0],
                Postcode = (string)set.Tables[0].Rows[rowIndex][1],
                Huisnummer = (string)set.Tables[0].Rows[rowIndex][2],
                Geboortedatum = (DateTime)set.Tables[0].Rows[rowIndex][3],
                Punten = (int)set.Tables[0].Rows[rowIndex][4],
                
                Id = (int)set.Tables[0].Rows[rowIndex][5],
                Email = (string)set.Tables[0].Rows[rowIndex][6],
                Naam = (string)set.Tables[0].Rows[rowIndex][7],
                AchterNaam = (string)set.Tables[0].Rows[rowIndex][8]
            };
        }
        public static Account DataSetToAccount(DataSet set, int rowIndex)
        {
            return new Account()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Email = (string)set.Tables[0].Rows[rowIndex][1],
                Password = (string)set.Tables[0].Rows[rowIndex][2],
                Naam = (string)set.Tables[0].Rows[rowIndex][3],
                AchterNaam = (string)set.Tables[0].Rows[rowIndex][4]
            };
        }
        public static Werknemer DataSetToWerknemer(DataSet set, int rowIndex)
        {
            return new Werknemer()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Naam = (string)set.Tables[0].Rows[rowIndex][1],
                AchterNaam = (string)set.Tables[0].Rows[rowIndex][2],
                Email = (string)set.Tables[0].Rows[rowIndex][3],
                FiliaalNaam = (string)set.Tables[0].Rows[rowIndex][4],
                FiliaalID = (int)set.Tables[0].Rows[rowIndex][5],
                WerknemerId = (int)set.Tables[0].Rows[rowIndex][6],
            };
        }
        public static Bestelling DataSetToBestelling(DataSet set, int rowIndex)
        {
            return new Bestelling()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Datum = (DateTime)set.Tables[0].Rows[rowIndex][1],
                KlantID = (int)set.Tables[0].Rows[rowIndex][2]

            };
        }

        public static DetailProduct DataSetToDetailProduct(DataSet set, int rowIndex)
        {
            return new DetailProduct()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                ProductId = (int)set.Tables[0].Rows[rowIndex][1],
                FiliaalId = (int)set.Tables[0].Rows[rowIndex][2],
                Verkocht = (bool)set.Tables[0].Rows[rowIndex][4]

            };
        }
        public static Product DataSetToProduct(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new Product()
                {
                    Id = (int)set.Tables[0].Rows[rowIndex][0],
                    CategorieId = (int)set.Tables[0].Rows[rowIndex][1],
                    Omschrijving = (string)set.Tables[0].Rows[rowIndex][2],
                    Naam = (string)set.Tables[0].Rows[rowIndex][3],
                    Aantal = (int)set.Tables[0].Rows[rowIndex][4],
                    Prijs = (string)set.Tables[0].Rows[rowIndex][5],
                    Soort = (string)set.Tables[0].Rows[rowIndex][6],
                    Actief = (bool)set.Tables[0].Rows[rowIndex][7],
                    Tweedehands = (bool)set.Tables[0].Rows[rowIndex][8],
                    CategorieNaam = (string)set.Tables[0].Rows[rowIndex][9],
                    ImagePath = (string)set.Tables[0].Rows[rowIndex][10]
                };
            }
            else
            {
                return new Product();
            }
        }
        public static Filiaal DataSetToFiliaal(DataSet set, int rowIndex)
        {
            return new Filiaal()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Stad = (string)set.Tables[0].Rows[rowIndex][1],
                Postcode = (string)set.Tables[0].Rows[rowIndex][3],
                Huisnummer = (string)set.Tables[0].Rows[rowIndex][2],
                Telefoonnummer = (string)set.Tables[0].Rows[rowIndex][4],
                Actief = (bool)set.Tables[0].Rows[rowIndex][5]
            };
        }
        public static Order DataSetToOrder(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new Order()
                {
                    Id = (int)set.Tables[0].Rows[rowIndex][0],
                    Datum = (DateTime)set.Tables[0].Rows[rowIndex][1],
                    OntvangerID = (int)set.Tables[0].Rows[rowIndex][2],
                    WerknemerID = (int)set.Tables[0].Rows[rowIndex][3],
                    Ontvangen = (bool)set.Tables[0].Rows[rowIndex][4],
                    Aantal = (int)set.Tables[0].Rows[rowIndex][5],
                    ProductID = (int)set.Tables[0].Rows[rowIndex][6],
                    VerzenderID = (int)set.Tables[0].Rows[rowIndex][7],
                    Verzonden = (bool)set.Tables[0].Rows[rowIndex][8]
                };
            }
            else
            {
                return new Order();
            }
        }
        public static ProductFoto DataSetToProductFoto(DataSet set, int rowIndex)
        {
            return new ProductFoto()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Foto = (Byte[])set.Tables[0].Rows[rowIndex][1]
            };
        }
        public static Categorie DataSetToCategorie(DataSet set, int rowIndex)
        {
            return new Categorie()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Naam = (string)set.Tables[0].Rows[rowIndex][1],
            };
        }
        public static Werknemer DataSetToWerknemerIndex(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new Werknemer()
                {
                    Id = (int)set.Tables[0].Rows[rowIndex][0],
                    Naam = (string)set.Tables[0].Rows[rowIndex][1],
                    AchterNaam = (string)set.Tables[0].Rows[rowIndex][2],
                    FiliaalNaam = (string)set.Tables[0].Rows[rowIndex][3],
                };
            }
            else
            {
                return new Werknemer();
            }
        }
        public static BestellingProduct DataSetToBestellingProduct(DataSet set, int rowIndex)
        {
            return new BestellingProduct()
            {
                Naam = (string)set.Tables[0].Rows[rowIndex][0],
                Omschrijving = (string)set.Tables[0].Rows[rowIndex][1],
                Aantal = (int)set.Tables[0].Rows[rowIndex][2],
                Prijs = (string)set.Tables[0].Rows[rowIndex][3],
                Datum = (DateTime)set.Tables[0].Rows[rowIndex][4],
            };
        }
    }
}
