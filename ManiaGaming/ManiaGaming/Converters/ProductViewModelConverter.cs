using ManiaGaming.Interfaces;
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
        public ProductDetailViewModel ModelToViewModel(Product p)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel()
            {
                ProductId = p.ProductId,
                Aantal = p.Aantal,
                Soort = p.Soort,
                Categorie = p.Categorie,
                Prijs = p.Prijs,
                Naam = p.Naam,
                Omschrijving = p.Omschrijving
            };

            return vm;
        }

        public Product ViewModelToModel(ProductDetailViewModel vm)
        {
            Product p = new Product()
            {
                ProductId = vm.ProductId,
                Aantal = vm.Aantal,
                Soort = vm.Soort,
                Categorie = vm.Categorie,
                Naam = vm.Naam,
                Omschrijving = vm.Omschrijving,
                Prijs = vm.Prijs
            };
            return p;
        }

    }
}
