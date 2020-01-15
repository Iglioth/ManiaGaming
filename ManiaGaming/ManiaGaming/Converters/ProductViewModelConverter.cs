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
        public List<ProductDetailViewModel> ModelsToViewModels(List<Product> models)
        {
            List<ProductDetailViewModel> productDetailViewModels = new List<ProductDetailViewModel>();

            foreach(Product p in models)
            {
                ProductDetailViewModel vm = new ProductDetailViewModel()
                {
                    Id = p.Id,
                    Aantal = p.Aantal,
                    Soort = p.Soort,
                    CategorieId = p.CategorieId,
                    Prijs = p.Prijs,
                    Naam = p.Naam,
                    Omschrijving = p.Omschrijving,
                    Actief = p.Actief,
                    CategorieNaam = p.CategorieNaam,
                    Tweedehands = p.Tweedehands
                    
                };
                productDetailViewModels.Add(vm);
            }

            return productDetailViewModels;
        }

        public ProductDetailViewModel ModelToViewModel(Product p)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel()
            {
                Id = p.Id,
                Aantal = p.Aantal,
                Soort = p.Soort,
                CategorieId = p.CategorieId,
                Prijs = p.Prijs,
                Naam = p.Naam,
                Omschrijving = p.Omschrijving,
                SoortList = GetSoorten(),
                Actief = p.Actief,
                CategorieNaam = p.CategorieNaam,
                Tweedehands = p.Tweedehands
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
                Id = vm.Id,
                Aantal = vm.Aantal,
                Soort = vm.Soort,
                CategorieId = vm.CategorieId,
                Naam = vm.Naam,
                Omschrijving = vm.Omschrijving,
                Prijs = vm.Prijs,
                Actief = vm.Actief,
                CategorieNaam = vm.CategorieNaam,
                Tweedehands = vm.Tweedehands
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
