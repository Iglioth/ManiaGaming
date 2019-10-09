﻿using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Converters
{
    public class BestellingViewModelConverter : IViewModelConverter<Bestelling, BestellingDetailViewModel>
    {
        public List<BestellingDetailViewModel> ModelsToViewModels(List<Bestelling> models)
        {
            throw new NotImplementedException();
        }

        public BestellingDetailViewModel ModelToViewModel(Bestelling b)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel()
            {
                BestellingId = b.BestellingId,
                Datum = b.Datum,
                KlantID = b.klantID
            };

            return vm;
        }

        public List<Bestelling> ViewModelsToModels(List<BestellingDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Bestelling ViewModelToModel(BestellingDetailViewModel vm)
        {
            Bestelling b = new Bestelling()
            {
                BestellingId = vm.BestellingId,
                Datum = vm.Datum,
                klantID = vm.KlantID
            };

            return b;
        }
    }
}
