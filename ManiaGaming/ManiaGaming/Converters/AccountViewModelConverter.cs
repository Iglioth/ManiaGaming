using ManiaGaming.Interfaces;
using ManiaGaming.Models;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Converters
{
    public class AccountViewModelConverter : IViewModelConverter<Account, AccountDetailViewModel>
    {
        public List<AccountDetailViewModel> ModelsToViewModels(List<Account> models)
        {
            throw new NotImplementedException();
        }

        public AccountDetailViewModel ModelToViewModel(Account a)
        {
            AccountDetailViewModel vm = new AccountDetailViewModel()
            {
                Id = a.Id,
                Email = a.Email,
                Password = a.Password,
                Naam = a.Naam,
                AchterNaam = a.AchterNaam
            };
            
            return vm;
        }

        public List<Account> ViewModelsToModels(List<AccountDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
        }

        public Account ViewModelToModel(AccountDetailViewModel vm)
        {
            Account ac = new Account()
            {
                Id = vm.Id,
                Email = vm.Email,
                Password = vm.Password,
                Naam = vm.Naam,
                AchterNaam = vm.AchterNaam
            };
            return ac;
        }
    }
}
