using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ManiaGaming.Controllers
{
    public class WinkelwagenController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();


        public WinkelwagenController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            WinkelwagenDetailViewModel cart = new WinkelwagenDetailViewModel();

            foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
            {
                cart.producten.Add(p);
            }
            
            
            return View(cart);
        }

        public IActionResult AddWinkelwagen(int id)
        {
           
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Product> cart = new List<Product>();
                Product p = productRepository.GetById(id);
                p.Aantal = 1;
                cart.Add(p);
               
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Product> cart = new List<Product>();
                Product p = productRepository.GetById(id);
                p.Aantal = 1;
                cart.Add(p);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
    
    }
}