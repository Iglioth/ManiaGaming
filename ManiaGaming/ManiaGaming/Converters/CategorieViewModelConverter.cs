using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Converters
{
    public class CategorieViewModelConverter : IViewModelConverter<Categorie, CategorieDetailViewModel>
    {
        public List<CategorieDetailViewModel> ModelsToViewModels(List<Categorie> model)
        {
            throw new NotImplementedException();
        }

        public CategorieDetailViewModel ModelToViewModel(Categorie model)
        {
            CategorieDetailViewModel vm = new CategorieDetailViewModel()
            {
                CategorieId = model.CategorieId,
                Naam = model.Naam
            };

            return vm;
        }

        public List<Categorie> ViewModelsToModels(List<CategorieDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Categorie ViewModelToModel(CategorieDetailViewModel viewModel)
        {
            Categorie c = new Categorie()
            {
                Naam = viewModel.Naam,
                CategorieId = viewModel.CategorieId
            };

            return c;
        }
    }
}
