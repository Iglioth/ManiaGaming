using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Models
{
    public class AccountViewModel : ZoekViewModel
    {
        public List<AccountDetailViewModel> Accounts { get; set; }
    }
}
