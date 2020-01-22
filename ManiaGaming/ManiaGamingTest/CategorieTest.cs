using ManiaGaming.Context.IContext;
using ManiaGaming.Context.ITestContext;
using ManiaGaming.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ManiaGamingTest
{
    [TestClass]
    public class CategorieTest
    {
        ICategorieContext Context;

        [TestInitialize]
        public void SetUp()
        {
            Context = new CategorieTestContext();
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

            Assert.IsFalse(TestBool);
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<Categorie> TestListCategorie = Context.GetAll();

            foreach (Categorie TestCategorie in TestListCategorie)
            {
                if (TestCategorie == null)
                {
                    Assert.Fail();
                }
            }
            Assert.IsNotNull(TestListCategorie);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Categorie TestCategorie = Context.GetById(1);

            Assert.IsNotNull(TestCategorie.Naam);
        }

        [TestMethod]
        public void GetByIdTestFail()
        {
            Categorie TestCategorie = Context.GetById(0);

            Assert.IsNull(TestCategorie);
        }

        [TestMethod]
        public void InsertTest()
        {
            long TestLong = Context.Insert(new Categorie() { Id = 1, Naam = "TestNaam", Actief = true});

            Assert.AreEqual(TestLong, 1);
        }

        [TestMethod]
        public void InsertTestFail()
        {
            long TestLong = Context.Insert(null);

            Assert.AreEqual(TestLong, 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            bool TestBool = Context.Update(new Categorie() { Id = 1, Naam = "TestNaam", Actief = true });

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
