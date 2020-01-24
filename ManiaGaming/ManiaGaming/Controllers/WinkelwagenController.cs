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
    [Authorize(Roles = "Klant")]
    public class WinkelwagenController : BaseController
    {
        // Repos
        private readonly ProductRepository productRepository;
        private readonly KlantRepository klantRepository;
        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();


        public WinkelwagenController
            (
                ProductRepository productRepository,KlantRepository klantRepository
            )
        {
            this.klantRepository = klantRepository;
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            
                WinkelwagenDetailViewModel cart = new WinkelwagenDetailViewModel();
                cart.klantPunten = GetKlantPunten();
                
                if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
                {
                ViewBag.Error = "Cart is leeg";
                return View();
                }
                else
                {
                    cart.KostenInPunten = ((int)GetKostenInPunten(CartProducten()) * 100);
                     
                    cart.ResterendeBedrag = ((int)GetKostenInPunten(CartProducten()) - (GetKlantPunten() / 100));
                    if(cart.ResterendeBedrag < 0)
                    {
                    cart.ResterendeBedrag = 0;
                    }
                    foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
                    {
                        cart.producten.Add(p);
                        cart.TotaalPrijs = cart.TotaalPrijs + Convert.ToDecimal(p.Prijs);
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


        public int GetKlantPunten()
        {
            long id = GetUserId();
            Klant k = klantRepository.GetById(id);
            return k.Punten;
        }
            
        public double GetKostenInPunten(List<Product> producten)
        {
            double Totaleprijs = 0;
            foreach (Product p in producten)
            {
                if (p.Aantal == 1)
                {
                    Totaleprijs += Convert.ToDouble(p.Prijs);
                }
                else
                {
                    Totaleprijs += (Convert.ToDouble(p.Prijs) * p.Aantal);
                }

            }

            return Totaleprijs;
        }
        public List<Product> CartProducten()
        {
            return SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"); ;
        }

    }
}