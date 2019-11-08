using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class FiliaalController : Controller
    {
        FiliaalRepository repo;
        FiliaalViewModelConverter converter = new FiliaalViewModelConverter();

        public FiliaalController(FiliaalRepository repo)
        {
            this.repo =  repo;
        }
        public IActionResult Index()
        {
            FiliaalViewModel vm = new FiliaalViewModel();
            List<Filiaal> filialen = new List<Filiaal>();
            filialen = repo.GetAll();
            vm.filiaalDetailViewModels = converter.ModelsToViewModels(filialen);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Insert(FiliaalDetailViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Filiaal f = converter.ViewModelToModel(vm);
                repo.Insert(f);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Insert");
            }
           
        }

        

    }
}