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
           
            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
            {
                List<Product> cart = new List<Product>();
                Product p = productRepository.GetById(id);
                p.Aantal = 1;
                cart.Add(p);

                SetSession(cart);
            }
            else
            {
                List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
                int index = Exist(cart, id);
                if (index  != -1)
                {
                    cart[index].Aantal++;
                    SetSession(cart); 
                }
                else
                {
                    
                    Product p = productRepository.GetById(id);
                    p.Aantal = 1;
                    cart.Add(p);
                    SetSession(cart);
                }
                
            }
            return RedirectToAction("Index");
        }

        private int Exist(List<Product> cart, int id)
        {
            

            for(int i = 0; i < cart.Count ; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                      return i;
                }
            }
       
            return -1;
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            List<Product> cart = GetSession();
            for(int i = 0; i < cart.Count; i++)
            {
                if(cart[i].Id == id)
                {
                    cart.RemoveAt(i);
                }
            }
            return RedirectToAction("Index");
        }

        private void SetSession(List<Product> cart)
        {
             SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); 
        }

        private List<Product>  GetSession()
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            return cart;
        }


    }
}