using ManiaGaming.Interfaces;
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
        public BestellingDetailViewModel ModelToViewModel(Bestelling b)
        {
            BestellingDetailViewModel vm = new BestellingDetailViewModel()
            {
                BestellingId = b.BestellingId,
                Aantal = b.Aantal,
                BestelNummer = b.BestelNummer,
                Datum = b.Datum
            };

            return vm;
        }

        public Bestelling ViewModelToModel(BestellingDetailViewModel vm)
        {
            Bestelling b = new Bestelling()
            {
                BestellingId = vm.BestellingId,
                BestelNummer = vm.BestelNummer,
                Aantal = vm.Aantal,
                Datum = vm.Datum
            };

            return b;
        }
    }
}
