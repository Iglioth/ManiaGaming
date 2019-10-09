using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;

namespace ManiaGaming.Converters
{
    public class FiliaalViewModelConverter : IViewModelConverter<Filiaal, FiliaalDetailViewModel>
    {
        public List<FiliaalDetailViewModel> ModelsToViewModels(List<Filiaal> models)
        {
            throw new NotImplementedException();
        }

        public FiliaalDetailViewModel ModelToViewModel(Filiaal f)
        {
            FiliaalDetailViewModel vm = new FiliaalDetailViewModel()
            {
                Filiaalid = f.FiliaalId,
                Huisnummer = f.Huisnummer,
                Postcode = f.Postcode,
                Telefoonnummer = f.Telefoonnummer

            };

            return vm;
        }

        public List<Filiaal> ViewModelsToModels(List<FiliaalDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Filiaal ViewModelToModel(FiliaalDetailViewModel viewModel)
        {
            Filiaal f = new Filiaal()
            {
                FiliaalId = viewModel.Filiaalid,
                Huisnummer = viewModel.Huisnummer,
                Postcode = viewModel.Postcode,
                Telefoonnummer = viewModel.Telefoonnummer
            };

            return f;
        }
    }
}
