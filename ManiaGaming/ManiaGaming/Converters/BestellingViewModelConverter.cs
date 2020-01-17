using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;

namespace ManiaGaming.Converters
{
    public class BestellingViewModelConverter : IViewModelConverter<Bestelling, BestellingDetailViewModel>, IViewModelConverter<BestellingProduct, BestellingProductDetailViewModel>
    {
        public List<BestellingDetailViewModel> ModelsToViewModels(List<Bestelling> models)
        {
            throw new NotImplementedException();
        }

        public List<BestellingProductDetailViewModel> ModelsToViewModels(List<BestellingProduct> models)
        {
            List<BestellingProductDetailViewModel> bestellingProductDetailViewModels = new List<BestellingProductDetailViewModel>();

            foreach (BestellingProduct p in models)
            {
                BestellingProductDetailViewModel vm = new BestellingProductDetailViewModel()
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
                    Tweedehands = p.Tweedehands,
                    BestellingId = p.BestellingId,
                    Datum = p.Datum,
                    KlantID = p.KlantID,
                    BestellingActief = p.BestellingActief

                };
                bestellingProductDetailViewModels.Add(vm);
            }

            return bestellingProductDetailViewModels;
        }

        public BestellingDetailViewModel ModelToViewModel(Bestelling b)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel()
            {
                Id = b.Id,
                Datum = b.Datum,
                KlantID = b.KlantID
            };

            return vm;
        }

        public BestellingProductDetailViewModel ModelToViewModel(BestellingProduct model)
        {
            throw new NotImplementedException();
        }

        public List<Bestelling> ViewModelsToModels(List<BestellingDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public List<BestellingProduct> ViewModelsToModels(List<BestellingProductDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Bestelling ViewModelToModel(BestellingDetailViewModel vm)
        {
            Bestelling b = new Bestelling()
            {
                Id = vm.Id,
                Datum = vm.Datum,
                KlantID = vm.KlantID
            };

            return b;
        }

        public BestellingProduct ViewModelToModel(BestellingProductDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
