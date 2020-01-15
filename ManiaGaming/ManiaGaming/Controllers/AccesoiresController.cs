﻿using ManiaGaming.Converters;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using ManiaGaming.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Controllers
{
    public class AccesoiresController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;
        private readonly CategorieRepository categorieRepository ;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();
        private readonly CategorieViewModelConverter categorieViewModelConverter = new CategorieViewModelConverter();
     
        

        public AccesoiresController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel
            {
                ProductDetailViewModels = converter.ModelsToViewModels(productRepository.GetAllAccesoires())
            };

            return View(vm);
        }



        public IActionResult Aanmaken()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
