using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Repositories
{
    public class AccountRepository
    {
        public readonly IAccountContext context ;

        public AccountRepository(IAccountContext context)
        {
            this.context = context ?? throw new NullReferenceException("De AccountContext is leeg.");
        }

        public List<Account> GetAll()
        {
            return GetAll();
        }

        public Account GetById(long id)
        {
            return GetById(id);
        }

        public bool Update(Account obj)
        {
            return Update(obj);
        }
    }
}
