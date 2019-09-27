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
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Postcode = set.Tables[0].Rows[rowIndex][1].ToString(),
                Huisnummer = set.Tables[0].Rows[rowIndex][2].ToString()
            };
        }
    }
}
