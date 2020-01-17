using ManiaGaming.Context.IContext;
using ManiaGaming.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManiaGaming.Context.ITestContext
{
    public class AccountTestContext : IAccountContext
    {
        public bool Actief(long id, bool actief)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAll()
        {
            List<Account> ListTestAccount = new List<Account>();
            ListTestAccount.Add(new Account()
            {
                Id = 1212,
                AchterNaam = "TestAchternaam",
                Actief = false,
                Email = "Email@Test.com",
                Naam = "TestNaam",
                Password = "TestPassword",
                NormalizedEmail = "TestNormalizedEmail",
                NormalizedUserName = "TestNormalizedUserName",
                RoleId = 2
            });

            return ListTestAccount;
        }

        public Account GetById(long id)
        {
            if (id > 0 && id != 0)
            {
                return new Account()
                {
                    Id = 1212,
                    AchterNaam = "TestAchternaam",
                    Actief = false,
                    Email = "Email@Test.com",
                    Naam = "TestNaam",
                    Password = "TestPassword",
                    NormalizedEmail = "TestNormalizedEmail",
                    NormalizedUserName = "TestNormalizedUserName",
                    RoleId = 2
                };
            }
            else
            {
                return null;
            }
        }

        public long Insert(Account obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Account obj)
        {
            if(obj != null && obj.Naam != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
