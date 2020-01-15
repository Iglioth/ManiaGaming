using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
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
        private readonly KlantViewModelConverter klantConverter = new KlantViewModelConverter();
        private readonly BestellingViewModelConverter bestellingConverter = new BestellingViewModelConverter();
        //private readonly AccountViewModelConverter accountController = new AccountViewModelConverter();


        public KlantController(KlantRepository klantRepositorys,BestellingRepository bestellingRepositorys,AccountRepository accountRepositorys)                                    
        {
            this.klantrepository = klantRepositorys;
            this.bestellingRepositorys = bestellingRepositorys;
            this.accountRepositorys = accountRepositorys;


        }

        public IActionResult Index(long id)
        {
     
            string rawValue = HttpContext.User.Identities.First().Claims.First().Value;
            if (string.IsNullOrEmpty(rawValue))
            {
                return View();
            }
            if (long.TryParse(rawValue, out id))
            {
                KlantDetailViewModel vm = new KlantDetailViewModel();
                Klant klant = klantrepository.GetById(id);
                vm = klantConverter.ModelToViewModel(klant);
                return View(vm);
            }
            return View();
            
        }
        [HttpGet]
        public IActionResult Aanpassen(long id)
        {
            KlantDetailViewModel vm = new KlantDetailViewModel();
            Klant klant = klantrepository.GetById(id);
            vm = klantConverter.ModelToViewModel(klant);
            return View(vm);
            
        }

        [HttpPost]
        public IActionResult Aanpassen(KlantDetailViewModel vm, long id)
        {
            string rawValue = HttpContext.User.Identities.First().Claims.First().Value;
            if (string.IsNullOrEmpty(rawValue))
            {
                return View();
            }
            if (long.TryParse(rawValue, out id))
            {
                Klant klant = klantConverter.ViewModelToModel(vm);
                bool check = klantrepository.Update(klant);
                return RedirectToAction("Index", new { vm.Id });
            }
            return View();
        }


        public IActionResult Gegevens()
        {
            return View("Gegevens");
        }

        public IActionResult Geschiedenis(long id)
        {
            
            BestellingProductViewModel vm = new BestellingProductViewModel();
            vm.BestellingProductDetailViewModels = bestellingConverter.ModelsToViewModels(bestellingRepositorys.GetAllById(id));
            return View(vm);
        }

        public IActionResult Bestellen()
        {
            return View("Bestellen");
        }

       


    }
}
