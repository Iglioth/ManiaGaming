﻿using ManiaGaming.Interfaces;
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
        public CategorieDetailViewModel ModelToViewModel(Categorie model)
        {
            CategorieDetailViewModel vm = new CategorieDetailViewModel()
            {
                CategorieID = model.CategorieID,
                CategorieNaam = model.CategorieNaam

            };

            return vm;
        }

        public Categorie ViewModelToModel(CategorieDetailViewModel viewModel)
        {
            Categorie c = new Categorie()
            {
                CategorieNaam = viewModel.CategorieNaam,
                CategorieID = viewModel.CategorieID
            };

            return c;
        }
    }
}
