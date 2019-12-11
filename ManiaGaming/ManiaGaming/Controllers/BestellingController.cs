using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class BestellingController : BaseController
    {
        BestellingRepository bestellingRepository;
        ProductRepository productRepository;

        public BestellingController(BestellingRepository bestellingRepository, ProductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.bestellingRepository = bestellingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Bestel(long id)
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            // Controlleren of klant ingelogt is en juiste gegevens zijn

            // De bestelling tevoegen
            //if(bestellingRepository.Bestellen(cart, id) == true)
            //{

            //}
                 
                 // De cart legen

            return View();
        }
    }
}