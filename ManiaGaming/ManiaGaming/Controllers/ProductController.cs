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
                CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll())
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Creëer(ProductDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Product product = productConverter.ViewModelToModel(vm);
                long Id = productRepository.Insert(product);
                return RedirectToAction("Aanpassen", new { Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
