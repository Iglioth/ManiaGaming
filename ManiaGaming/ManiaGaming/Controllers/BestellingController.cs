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
    public class BestellingController : Controller
    {
        BestellingRepository bestellingRepository;
        ProductRepository productRepository;
        AccountRepository accountRepository;

        public BestellingController(BestellingRepository bestellingRepository, ProductRepository productRepository, AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
            this.productRepository = productRepository;
            this.bestellingRepository = bestellingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Bestel(AccountDetailViewModel vm)
        {

            // Controlleren of klant ingelogt is en juiste gegevens zijn
            if(ControlUser(vm) == true)
            {

           
                List<Product> cart = CartProducten();
                if (cart != null)
                {
                    Klant k = new Klant();
                    k.Id = 1; //Moet een Session worden 

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
                    return RedirectToAction("Index","WinkelWagen");
                }

            }
            else
            {
              
                //Bestelling mislukt, want wachtwoord of/en email zijn fout. DIRK VRAGEN OM ERRORCODE
                return RedirectToAction("Index");

            }
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