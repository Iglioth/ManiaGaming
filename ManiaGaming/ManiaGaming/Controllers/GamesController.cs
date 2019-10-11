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
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.productDetailViewModels = converter.ModelsToViewModels(productRepository.GetAll());

            return View("Index", productViewModel);
        }

        public IActionResult Detail()
        {
            ViewData["Message"] = "Your application description page.";

            return View("Detail");
        }

    }
}
