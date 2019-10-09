using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Converters
{
    public class CategorieController : Controller
    {
        // Repos
        private readonly CategorieRepository categorieRepository;

        // Converter 
        private readonly CategorieViewModelConverter converter = new CategorieViewModelConverter();

        public CategorieController
            (
                CategorieRepository categorieRepository
            )
        {
            this.categorieRepository = categorieRepository;
        }

        public IActionResult Index()
        {
            CategorieViewModel vm = new CategorieViewModel();
            List<Categorie> categories = new List<Categorie>();
            categories = categorieRepository.GetAll();
            vm.CategorieDetailViewModels = converter.ModelsToViewModels(categories);
            return View(vm);
        }

        public IActionResult Aanmaken()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        public IActionResult Aanmaken(CategorieDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Categorie categorie = converter.ViewModelToModel(vm);
                long id = categorieRepository.Insert(categorie);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
