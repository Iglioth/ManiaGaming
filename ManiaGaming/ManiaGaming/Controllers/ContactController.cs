using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Controllers
{
    public class ContactController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        //private readonly ProductViewModelConverter converter = new ProductViewModelConverter();

        public ContactController
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
    }
}
