using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Converters
{
    public class WerknemerViewModelConverter : IViewModelConverter<Werknemer, WerknemerDetailViewModel>
    {
        public List<WerknemerDetailViewModel> ModelsToViewModels(List<Werknemer> models)
        {
            List<WerknemerDetailViewModel> result = new List<WerknemerDetailViewModel>();

            foreach (Werknemer p in models)
            {
                result.Add(ModelToViewModel(p));
            }
            return result;
        }

        public WerknemerDetailViewModel ModelToViewModel(Werknemer model)
        {
            WerknemerDetailViewModel vm = new WerknemerDetailViewModel()
            {
                Id = model.Id,
                AchterNaam = model.AchterNaam,
                Email = model.Email,
                Naam = model.Naam,
                Password = model.Password,
                Actief = model.Actief,
                WerknemerId = model.WerknemerId,
            };

            return vm;
        }

        public List<Werknemer> ViewModelsToModels(List<WerknemerDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Werknemer ViewModelToModel(WerknemerDetailViewModel viewModel)
        {
            Werknemer model = new Werknemer()
            {
                Id = viewModel.Id,
                AchterNaam = viewModel.AchterNaam,
                Email = viewModel.Email,
                Naam = viewModel.Naam,
                Password = viewModel.Password,
                Actief = viewModel.Actief,
                WerknemerId = viewModel.WerknemerId,
                FiliaalID = viewModel.FiliaalId,
            };

            return model;
        }
    }
}
