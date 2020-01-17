using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Controllers
{
    [AllowAnonymous]
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
            
            //if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
            //{
              
            //    return View();
            //}
            //else
            //{
                WinkelwagenDetailViewModel cart = new WinkelwagenDetailViewModel();
                if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
                {
                ViewBag.Error = "Inloggegevens zijn incorrect";
                return View();
                }
                else
                {
                    foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
                    {
                        cart.producten.Add(p);
                    }
                }
                return View(cart);
            
        }
        [HttpGet]
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
                int index = Exist( id);
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

     

        public IActionResult Remove(long id)
        {
            List<Product> cart = GetSession();
            int index = Exist(Convert.ToInt32(id));
            cart.RemoveAt(index);
            SetSession(cart);
            
            return RedirectToAction("Index");
        }


        private int Exist(int id)
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        private void SetSession(List<Product> cart)
        {
             SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart); 
        }

        private List<Product>  GetSession()
        {
            return  SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
           
        }


    }
}