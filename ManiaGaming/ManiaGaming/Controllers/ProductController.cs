﻿using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManiaGaming.Controllers
{
    [Authorize(Roles = "Beheerder, Werknemer")]
    public class ProductController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;
        private readonly CategorieRepository categorieRepository;

        // Converter 
        private readonly ProductViewModelConverter productConverter = new ProductViewModelConverter();
        private readonly CategorieViewModelConverter categorieConverter = new CategorieViewModelConverter();

        public ProductController
            (
                ProductRepository productRepository,
                CategorieRepository categorieRepository
            )
        {
            this.productRepository = productRepository;
            this.categorieRepository = categorieRepository;
        }

        [HttpGet]
        public IActionResult Aanmaken()
        {
            ProductDetailViewModel vm = new ProductDetailViewModel
            {
                CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll()),
                SoortList = productConverter.GetSoorten()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel();
            Product product = productRepository.GetById(id);
            vm = productConverter.ModelToViewModel(product);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel()
            {
                SoortList = productConverter.GetSoorten()
            };
            List<Product> products = new List<Product>();
            products = productRepository.GetAll();
            vm.ProductDetailViewModels = productConverter.ModelsToViewModels(products);
            vm.CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll());
            return View(vm);
        }

        [HttpGet]
        public IActionResult Activeren(long id)
        {
            Product product = productRepository.GetById(id);
            productRepository.Actief(id, product.Actief);
            return RedirectToAction("Index");
        }

        /*[HttpGet]
        public IActionResult Aanpassen(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel
            {
                SoortList = productConverter.GetSoorten()
            };
            Product product = productRepository.GetById(id);
            vm = productConverter.ModelToViewModel(product);
            vm.CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll());
            return View(vm);
        }*/

        [HttpPost]
        public IActionResult Aanpassen(ProductDetailViewModel vm)
        {           
            Product product = productConverter.ViewModelToModel(vm);
            bool check = productRepository.Update(product);
            return RedirectToAction("Index", new { vm.Id });           
        }

        [HttpPost]
        public IActionResult Aanmaken(ProductDetailViewModel vm)
        {
            vm.CategorieList = new List<CategorieDetailViewModel>();
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Product product = productConverter.ViewModelToModel(vm);
                long Id = productRepository.Insert(product);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Deactiveren(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel()
            {
                SoortList = productConverter.GetSoorten()
            };
            Product product = productRepository.GetById(id);
            vm = productConverter.ModelToViewModel(product);
            vm.CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll());
            return View(vm);
        }

        [HttpGet]
        public IActionResult VeranderStock(long Id)
        {
            Product product = productRepository.GetById(Id);
            ProductDetailViewModel vm = productConverter.ModelToViewModel(product);
            return View(vm);
        }
        [HttpPost]
        public IActionResult VeranderStock(ProductDetailViewModel vm, long Id)
        {
            if (ModelState.IsValid)
            {
                vm.CategorieList = new List<CategorieDetailViewModel>();
                Product product = productConverter.ViewModelToModel(vm);
                bool check = productRepository.VeranderStock(Id, product);
                return RedirectToAction("VeranderStock", new { Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Zoeken(string zoekterm)
        {
            return RedirectToAction("Resultaat", new { zoekterm});
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Resultaat(string zoekterm)
        {
            if(zoekterm == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ProductViewModel vm = new ProductViewModel()
            {
                SoortList = productConverter.GetSoorten()
            };
            List<Product> products = new List<Product>();
            products = productRepository.Zoeken(zoekterm);
            vm.ProductDetailViewModels = productConverter.ModelsToViewModels(products);
            vm.CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll());
            return View(vm);
        }
    }
}
