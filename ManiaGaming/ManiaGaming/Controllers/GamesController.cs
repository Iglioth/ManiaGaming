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
    public class GamesController : Controller 
    { 
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();
       

        public GamesController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();
            vm.ProductDetailViewModels = converter.ModelsToViewModels(productRepository.GetAll());

            return View(vm);
        }

        public IActionResult Detail(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel
            {
                SoortList = converter.GetSoorten()
            };
            Product product = productRepository.GetById(id);
            vm = converter.ModelToViewModel(product);
            
            return View(vm);
        }

    }
}
