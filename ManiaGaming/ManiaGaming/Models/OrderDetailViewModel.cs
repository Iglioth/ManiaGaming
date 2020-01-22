using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManiaGaming.Models
{
    public class OrderDetailViewModel : ZoekViewModel
    {   
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public int WerknemerID { get; set; }
        public int VerzenderID { get; set; }
        public int OntvangerID { get; set; }
        public bool Ontvangen { get; set; }
        public bool Verzonden { get; set; }
        public List<Filiaal> Filialen { get; set; }
        public List<Product> Producten { get; set; }
        public int ProductId { get; set; }
        public int Aantal { get; set; }
        
    }
}
