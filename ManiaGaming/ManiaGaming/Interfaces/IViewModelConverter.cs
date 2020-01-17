using System.Collections.Generic;

namespace ManiaGaming.Interfaces
{
    public interface IViewModelConverter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewModel);

        List<TViewModel> ModelsToViewModels(List<TModel> models);
        List<TModel> ViewModelsToModels(List<TViewModel> viewModels);
    }
}
