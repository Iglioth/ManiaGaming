using System;
using System.Collections.Generic;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles ="Klant")]
        public IActionResult Bestel()
        {
                List<Product> cart = CartProducten();
                if (cart != null)
                {
                   
                    long id = GetUserId();
                    klantRepository.GetKlantID(id);
                    Klant k = klantRepository.GetById(id);
                    
                    if (bestellingRepository.Bestellen(cart, k.Id) == true)
                    {
                    int punten = Convert.ToInt32(BerekenPoints(cart));
                    klantRepository.UpdateKlantPunten(punten,Convert.ToInt32(GetUserId()));
                    //update klant punten
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
                     
                    return RedirectToAction("Index", "WinkelWagen");
                }
        }

        public IActionResult BestellingBevestiging()
        {
            return View();
        }
       

        //public bool ControlUser(AccountDetailViewModel vm)
        //{
        //    Account a = accountRepository.GetById(1/*Hier komt SessionID te staan*/);
        //    if(a.Email == vm.Email && a.Password == vm.Password)
        //    {
        //        return true;
        //    }
           
        //    return false;
        //}

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
        private double BerekenPoints(List<Product> producten)
        {
            double punten = 0;
            double prijs;

            foreach (Product p in producten)
            {
                double prijsperproduct = Convert.ToDouble(p.Prijs);

                if (p.Aantal > 1)
                {

                    prijs = prijsperproduct * p.Aantal;
                    punten = +prijs;
                }
                else
                {
                    punten =+ Convert.ToDouble(p.Prijs);
                }
                    
               
            }
            return punten;
        }


    }
}