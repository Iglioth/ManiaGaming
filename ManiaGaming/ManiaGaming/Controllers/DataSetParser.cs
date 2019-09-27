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
                Aantal = (int)set.Tables[0].Rows[rowIndex][0],

            };
        }
    }
}
