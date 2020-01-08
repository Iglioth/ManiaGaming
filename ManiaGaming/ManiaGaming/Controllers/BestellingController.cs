using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ManiaGaming.Controllers
{
    public class BestellingController : BaseController
    {
        BestellingRepository bestellingRepository;
        ProductRepository productRepository;
        AccountRepository accountRepository;
        KlantRepository klantRepository;
        public BestellingController(BestellingRepository bestellingRepository, ProductRepository productRepository, AccountRepository accountRepository, KlantRepository klantRepository)
        {
            this.klantRepository = klantRepository;
            this.accountRepository = accountRepository;
            this.productRepository = productRepository;
            this.bestellingRepository = bestellingRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

 
        public IActionResult Bestel()
        {

            // Controlleren of klant ingelogt is en juiste gegevens zijn
            //if (GetUserId() != -1)
            //{

                List<Product> cart = CartProducten();
                if (cart != null)
                {
                    long id = GetUserId();
                    klantRepository.GetKlantID(id);
                    Klant k = klantRepository.GetById(id);

                    if (bestellingRepository.Bestellen(cart, k.Id) == true)
                    {
                        DeleteCartProducts(cart);

                        return View("BestellingBevestiging");
                    }
                    else
                    {
                        return RedirectToAction("Index", "WinkelWagen");
                    }
                   
                }
                else
                {
                    //aangeven dat de winkelwagen leeg is  
                    return RedirectToAction("Index", "WinkelWagen");
                }

            //}
            //else
            //{

            //    //Bestelling mislukt, want er is niemand ingelogd ERRORCODE
            //    return RedirectToAction("Index", "LoginController");

            //}
        }

        public IActionResult BestellingBevestiging()
        {
            return View();
        }
       



        public bool ControlUser(AccountDetailViewModel vm)
        {
            Account a = accountRepository.GetById(1/*Hier komt SessionID te staan*/);
            if(a.Email == vm.Email && a.Password == vm.Password)
            {
                return true;
            }
           
            return false;
        }

        public List<Product> CartProducten()
        {
            return SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"); ;
        }

        public void DeleteCartProducts(List<Product> cart)
        {
            List<Product> producten = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }
    }
}