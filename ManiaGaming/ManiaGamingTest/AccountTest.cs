using ManiaGaming.Context.IContext;
using ManiaGaming.Context.ITestContext;
using ManiaGaming.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManiaGaming.Test
{
    public class AccountTest
    {
        IAccountContext Context;

        [TestInitialize]
        public void SetUp()
        {
            Context = new IAccountTest();
            Context.Insert(new Account()
            {
                Id = 5648,
                AchterNaam = "TestAchternaam",
                Actief = false,
                Email = "Email@Test.com",
                Naam = "TestNaam",
                Password = "TestPassword",
                NormalizedEmail = "TestNormalizedEmail",
                NormalizedUserName = "TestNormalizedUserName",
                RoleId = 1
            });
        }

        [TestMethod]
        public void InsertTest()
        {
            long TestLong = Context.Insert(new Account()
            {
                Id = 5648,
                AchterNaam = "TestAchternaam",
                Actief = false,
                Email = "Email@Test.com",
                Naam = "TestNaam",
                Password = "TestPassword",
                NormalizedEmail = "TestNormalizedEmail",
                NormalizedUserName = "TestNormalizedUserName",
                RoleId = 1
            });

            Assert.IsNotNull(TestLong);
        }

        [TestMethod]
        public void InsertTestFail()
        {
            long TestLong = Context.Insert(null);
            
            Assert.IsNull(TestLong);
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<Account> TestListAccount = Context.GetAll();

            

            foreach(Account TestAccount in TestListAccount)
            {
                if(TestAccount == null)
                {
                    Assert.Fail();
                }
            }
            Assert.IsNotNull(TestListAccount);
        }

        /*
        [TestMethod]
        public void GetAllTestFail()
        {
            List<Account> TestListAccount = Context.GetAll();



            foreach (Account TestAccount in TestListAccount)
            {
                if (TestAccount == null)
                {
                    Assert.Fail();
                }
            }
            Assert.IsNotNull(TestListAccount);
        }

        [TestMethod]
        public void ActiefTest()
        {
            bool TestBool = Context.Actief(1, true);

            Assert.IsTrue(TestBool);
        }

        [TestMethod]
        public void ActiefTestFail()
        {
            bool TestBool = Context.Actief(0, false);

            Assert.IsFalse();
        }*/

        [TestMethod]
        public void GetByIdTest()
        {
            Account TestAccount = Context.GetById(1);

            Assert.IsNotNull(TestAccount.Id);
        }

        [TestMethod]
        public void GetByIdTestFail()
        {
            Account TestAccount = Context.GetById(0);

            Assert.IsNull(TestAccount.Id);
        }

        [TestMethod]
        public void UpdateTest()
        {
            bool TestBool = Context.Update(new Account()
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

            Assert.IsTrue(TestBool);
        }

        [TestMethod]
        public void UpdateTestFail()
        {
            bool TestBool = Context.Update(null);

            Assert.IsFalse(TestBool);
        }
    }
}
