﻿using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Converters
{
    public class ProductViewModelConverter : IViewModelConverter<Product, ProductDetailViewModel>
    {
        public List<ProductDetailViewModel> ModelsToViewModels(List<Product> models)
        {
            List<ProductDetailViewModel> productDetailViewModels = new List<ProductDetailViewModel>();

            foreach(Product p in models)
            {
                ProductDetailViewModel vm = new ProductDetailViewModel()
                {
                    ProductId = p.ProductId,
                    Aantal = p.Aantal,
                    Soort = p.Soort,
                    CategorieId = p.CategorieId,
                    Prijs = p.Prijs,
                    Naam = p.Naam,
                    Omschrijving = p.Omschrijving
                };
                productDetailViewModels.Add(vm);
            }

            return productDetailViewModels;
        }

        public ProductDetailViewModel ModelToViewModel(Product p)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel()
            {
                ProductId = p.ProductId,
                Aantal = p.Aantal,
                Soort = p.Soort,
                CategorieId = p.CategorieId,
                Prijs = p.Prijs,
                Naam = p.Naam,
                Omschrijving = p.Omschrijving,
                SoortList = GetSoorten(),
            };

            return vm;
        }

        public List<Product> ViewModelsToModels(List<ProductDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Product ViewModelToModel(ProductDetailViewModel vm)
        {
            Product p = new Product()
            {
                ProductId = vm.ProductId,
                Aantal = vm.Aantal,
                Soort = vm.Soort,
                CategorieId = vm.CategorieId,
                Naam = vm.Naam,
                Omschrijving = vm.Omschrijving,
                Prijs = vm.Prijs
            };
            return p;
        }

        public List<string> GetSoorten()
        {
            List<string> soort = new List<string>()
            {
                "Spel",
                "Spelcomputer",
                "Accesoire",
                "Merchandise"
            };
            return soort;
        }
    }
}
