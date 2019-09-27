using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Models.Data;
using ManiaGaming.Models;
using ManiaGaming.Interfaces;

namespace ManiaGaming.Converters
{
    public class KlantViewModelConverter : IViewModelConverter<Klant, KlantDetailViewModel>
    {
     
        public KlantDetailViewModel ModelToViewModel(Klant k)
        {
            KlantDetailViewModel vm = new KlantDetailViewModel()
            {
                KlantId = k.KlantId,
                Geboortedatum = k.Geboortedatum,
                Huisnummer = k.Huisnummer,
                Postcode = k.Postcode,
                Punten = k.Punten,
                AccountId = k.AccountId,
                AchterNaam = k.AchterNaam,
                Email = k.Email,
                Naam = k.Naam,
                Password = k.Password

            };

            return vm;
        }

        public Klant ViewModelToModel(KlantDetailViewModel vm)
        {
            Klant k = new Klant()
            {
                KlantId = vm.KlantId,
                AccountId = vm.AccountId,
                AchterNaam = vm.AchterNaam,
                Email = vm.Email,
                Geboortedatum = vm.Geboortedatum,
                Huisnummer = vm.Huisnummer,
                Naam = vm.Naam,
                Password = vm.Password,
                Postcode = vm.Postcode,
                Punten = vm.Punten
            };

            return k;
        }
    }
}
