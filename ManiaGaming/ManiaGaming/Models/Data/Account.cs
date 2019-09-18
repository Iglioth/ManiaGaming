using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models.Data
{
    public class Account
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NormalizedEmail { get; set; }
        public string Naam { get; set; }
        public string AchterNaam { get; set; }
    }
}
