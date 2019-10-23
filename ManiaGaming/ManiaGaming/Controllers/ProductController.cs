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
                CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll()),
                SoortList = productConverter.GetSoorten()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();
            List<Product> products = new List<Product>();
            products = productRepository.GetAll();
            vm.ProductDetailViewModels = productConverter.ModelsToViewModels(products);

            return View(vm);
        }

        [HttpGet]
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
                return RedirectToAction("Aanpassen", new { Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
