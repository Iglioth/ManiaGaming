using ManiaGaming.Models;
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

        // Converter 
        //private readonly ProductViewModelConverter converter = new ProductViewModelConverter();

        public ProductController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Aanmaken()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        /*[HttpPost]
        public IActionResult Aanmaken(ProductDetailViewModel vm)
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }*/
    }
}
