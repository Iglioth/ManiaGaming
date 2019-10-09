using ManiaGaming.Converters;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Controllers
{
    public class KlantController : Controller
    {

        // repos
        private readonly KlantRepository klantrepository;
        private readonly BestellingRepository bestellingRepositorys;
        private readonly AccountRepository accountRepositorys;

        //converter
        private readonly KlantViewModelConverter productController = new KlantViewModelConverter();
        private readonly BestellingViewModelConverter bestelcontroller = new BestellingViewModelConverter();
        //private readonly AccountViewModelConverter accountController = new AccountViewModelConverter();


        public KlantController(KlantRepository klantRepositorys,BestellingRepository bestellingRepositorys,AccountRepository accountRepositorys)                                    
        {
            this.klantrepository = klantRepositorys;
            this.bestellingRepositorys = bestellingRepositorys;
            this.accountRepositorys = accountRepositorys;


        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Gegevens()
        {
            return View("Gegevens");
        }

        public IActionResult Geschiedenis()
        {
            return View("Geschiedenis");
        }

        public IActionResult Bestellen()
        {
            return View("Bestellen");
        }


    }
}
