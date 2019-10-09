using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Interfaces
{
    public interface IViewModelConverter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewModel);

        List<TViewModel> ModelsToViewModels(List<TModel> model);
        List<TModel> ViewModelsToModels(List<TViewModel> viewModels);
    }
}
