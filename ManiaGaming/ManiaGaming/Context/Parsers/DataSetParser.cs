using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Controllers
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
                AccountId = (int)set.Tables[0].Rows[rowIndex][5]
            };
        }
        public static Account DataSetToAccount(DataSet set, int rowIndex)
        {
            return new Account()
            {
                AccountId = (int)set.Tables[0].Rows[rowIndex][0],
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
                WerknemerId = (int)set.Tables[0].Rows[rowIndex][0],
                functie = (string)set.Tables[0].Rows[rowIndex][1],
                AccountId = (int)set.Tables[0].Rows[rowIndex][2]
            };
        }
        public static Bestelling DataSetToBestelling(DataSet set, int rowIndex)
        {
            return new Bestelling()
            {
                BestellingId = (int)set.Tables[0].Rows[rowIndex][0],
                Datum = (DateTime)set.Tables[0].Rows[rowIndex][1],
                BestelNummer = (int)set.Tables[0].Rows[rowIndex][2],
                Aantal = (int)set.Tables[0].Rows[rowIndex][3]

            };
        }

        public static DetailProduct DataSetToDetailProduct(DataSet set, int rowIndex)
        {
            return new DetailProduct()
            {
                DetailProductId = (int)set.Tables[0].Rows[rowIndex][0],
                ProductId = (int)set.Tables[0].Rows[rowIndex][1],
                FiliaalId = (int)set.Tables[0].Rows[rowIndex][2],
                Retour = (bool)set.Tables[0].Rows[rowIndex][3],
                Verkocht = (bool)set.Tables[0].Rows[rowIndex][4]

            };
        }
        public static Product DataSetToProduct(DataSet set, int rowIndex)
        {
            return new Product()
            {
                ProductId = (int)set.Tables[0].Rows[rowIndex][0],
                Aantal = (int)set.Tables[0].Rows[rowIndex][1],
                Naam = (string)set.Tables[0].Rows[rowIndex][2],
                Categorie = (string)set.Tables[0].Rows[rowIndex][3],
                Omschrijving = (string)set.Tables[0].Rows[rowIndex][4],
                Prijs = (int)set.Tables[0].Rows[rowIndex][5]

            };
        }
        public static Filiaal DataSetToFiliaal(DataSet set, int rowIndex)
        {
            return new Filiaal()
            {
                FiliaalId = (int)set.Tables[0].Rows[rowIndex][0],
                Postcode = (string)set.Tables[0].Rows[rowIndex][1],
                Huisnummer = (string)set.Tables[0].Rows[rowIndex][2],
                Telefoonnummer = (int)set.Tables[0].Rows[rowIndex][3],
                

            };
        }
        public static Order DataSetToOrder(DataSet set, int rowIndex)
        {
            return new Order()
            {
                OrderId = (int)set.Tables[0].Rows[rowIndex][0],
                Datum = (DateTime)set.Tables[0].Rows[rowIndex][1],
                ProductNummer = (int)set.Tables[0].Rows[rowIndex][2],
                ProductNaam = (string)set.Tables[0].Rows[rowIndex][3],
                Aantal = (int)set.Tables[0].Rows[rowIndex][3],

            };
        }
        public static ProductFoto DataSetToProductFoto(DataSet set, int rowIndex)
        {
            return new ProductFoto()
            {
                ProductFotoId = (int)set.Tables[0].Rows[rowIndex][0],
                Foto = (Byte[])set.Tables[0].Rows[rowIndex][1]
               


            };
        }
    }
}
