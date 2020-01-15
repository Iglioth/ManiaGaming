﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models;
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
    }
}