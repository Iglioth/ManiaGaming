﻿using System.Collections.Generic;
using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    [Authorize(Roles = "Beheerder, Werknemer")]
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

        //public IActionResult Delete(long id)
        //{
        //    Filiaal f = repo.GetById(id);
        //    repo.Delete(f);
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public IActionResult Aanpassen(long id)
        {
            FiliaalDetailViewModel vm = new FiliaalDetailViewModel();
            Filiaal f = repo.GetById(id);
            vm = converter.ModelToViewModel(f);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Aanpassen(FiliaalDetailViewModel vm)
        {
            Filiaal f = converter.ViewModelToModel(vm);
            repo.Update(f);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Activeren(long id)
        {

            Filiaal f = repo.GetById(id);
            repo.Actief(id, f.Actief);

            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult Deactiveren(long id)
        //{
            

        //    FiliaalDetailViewModel vm = new FiliaalDetailViewModel();
        //    Filiaal f = repo.GetById(id);
        //    vm = converter.ModelToViewModel(f);
        //    return View(vm);
        //}

     



    }
}