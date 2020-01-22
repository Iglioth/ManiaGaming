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


        public IActionResult BestelMetPunten()
        {

            if(ControlleerKorting(CartProducten(), GetKlantPunten()) == false)
            {
                ViewBag.Error = "Helaas heeft u niet voldoende punten om korting te verkrijgen";
                return View();
            }
            else
            {
                double totaalprijs = GetTotalePrijs(CartProducten());
                int TotaleKortingInPunten = GetKlantPunten();
                int totaalbedragInPunten = (int)totaalprijs * 100;
                int berekening = totaalbedragInPunten - TotaleKortingInPunten;

                if (berekening > 0)
                {
                    klantRepository.UpdateKlantPuntenNaBestelling(TotaleKortingInPunten, GetUserId());  
                }
                else
                {
                    klantRepository.UpdateKlantPuntenNaBestelling(totaalbedragInPunten, GetUserId());  
                }
                return View("BestellingBevestiging");
            }

            
        }

        public bool ControlleerKorting(List<Product> producten,int klantpunten)
        { 
            int Korting = klantpunten / 100;
           
            if (Korting == 0)
            {
                return false;
            }
            else
            {
                return true;
            } 
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
                    punten += prijs;
                }
                else
                {
                    punten += prijsperproduct;
                } 
                    
               
            }
            return punten;
        }

        public int GetKlantPunten()
        {
            long id = GetUserId();
            Klant k = klantRepository.GetById(id);
            return k.Punten;
        }
        public double GetTotalePrijs(List<Product> producten)
        {
            double Totaleprijs = 0;
            foreach (Product p in producten)
            {
                if (p.Aantal > 1)
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

    }
}