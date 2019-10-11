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
            throw new NotImplementedException();
        }

        public ProductDetailViewModel ModelToViewModel(Product p)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel()
            {
                Id = p.ProductId,
                Aantal = p.Aantal,
                Soort = p.Soort,
                CategorieId = p.CategorieId,
                Prijs = p.Prijs,
                Naam = p.Naam,
                Omschrijving = p.Omschrijving
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
                ProductId = vm.Id,
                Aantal = vm.Aantal,
                Soort = vm.Soort,
                CategorieId = vm.CategorieId,
                Naam = vm.Naam,
                Omschrijving = vm.Omschrijving,
                Prijs = vm.Prijs
            };
            return p;
        }

    }
}
