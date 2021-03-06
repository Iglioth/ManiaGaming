﻿using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        public IActionResult Index()
        {
            CategorieViewModel vm = new CategorieViewModel();
            List<Categorie> categories = new List<Categorie>();
            categories = categorieRepository.GetAll();
            vm.CategorieDetailViewModels = converter.ModelsToViewModels(categories);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Aanmaken()
        { 
            return View();
        }

        [HttpGet]
        public IActionResult Aanpassen(long id)
        {
            Categorie categorie = categorieRepository.GetById(id);
            CategorieDetailViewModel vm = converter.ModelToViewModel(categorie);
            return View(vm);
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

        [HttpPost]
        public IActionResult Aanpassen(CategorieDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Categorie categorie = converter.ViewModelToModel(vm);
                bool Update = categorieRepository.Update(categorie);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
