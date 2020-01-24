using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManiaGaming.Controllers
{
    [Authorize(Roles = "Beheerder, Werknemer")]
    public class WerknemerController : BaseController
    {
        // Repos
        private readonly WerknemerRepository werknemerRepository;
        private readonly FiliaalRepository filiaalRepository;

        // Converter 
        private readonly WerknemerViewModelConverter werknemerConverter = new WerknemerViewModelConverter();
        private readonly FiliaalViewModelConverter filiaalConverter = new FiliaalViewModelConverter();

        public WerknemerController
            (
                WerknemerRepository werknemerRepository, 
                FiliaalRepository filiaalRepository
            )
        {
            this.werknemerRepository = werknemerRepository;
            this.filiaalRepository = filiaalRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            WerknemerViewModel vm = new WerknemerViewModel();
            List<Werknemer> werknemers = new List<Werknemer>();
            werknemers = werknemerRepository.GetAll();
            vm.WerknemerDetailViewModels = werknemerConverter.ModelsToViewModels(werknemers);
            vm.FiliaalList = filiaalConverter.ModelsToViewModels(filiaalRepository.GetAll());
            for(int i = 0; i < vm.WerknemerDetailViewModels.Count(); i ++)
            {
                vm.WerknemerDetailViewModels[i].FiliaalLocatie = werknemers[i].FiliaalNaam;
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Aanmaken()
        {
            WerknemerDetailViewModel vm = new WerknemerDetailViewModel
            {
                FiliaalList = filiaalRepository.GetAll()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Aanmaken(WerknemerDetailViewModel vm)
        {
            Werknemer werknemer = new Werknemer();
            werknemer = werknemerConverter.ViewModelToModel(vm);
            werknemerRepository.Insert(werknemer);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Aanpassen(WerknemerDetailViewModel vm)
        {
            Werknemer werknemer = werknemerConverter.ViewModelToModel(vm);
            werknemer.FiliaalID = Convert.ToInt32(vm.FiliaalLocatie);
            bool check = werknemerRepository.Update(werknemer);
            return RedirectToAction("Index", new { vm.Id });
        }
    }
}
