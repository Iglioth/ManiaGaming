﻿using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Converters
{
    public class CategorieViewModelConverter : IViewModelConverter<Categorie, CategorieDetailViewModel>
    {
        public List<CategorieDetailViewModel> ModelsToViewModels(List<Categorie> models)
        {
            List<CategorieDetailViewModel> result = new List<CategorieDetailViewModel>();

            foreach (Categorie d in models)
            {
                result.Add(ModelToViewModel(d));
            }
            return result;
        }

        public CategorieDetailViewModel ModelToViewModel(Categorie model)
        {
            CategorieDetailViewModel vm = new CategorieDetailViewModel()
            {
                Id = model.Id,
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
                Id = viewModel.Id
            };

            return c;
        }
    }
}
