using ManiaGaming.Context.IContext;
using ManiaGaming.Context.ITestContext;
using ManiaGaming.Models.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManiaGaming.Test
{
    class BestellingTest
    {
        IBestellingContext Context;

        [TestInitialize]
        public void SetUp()
        {
            Context = new IBestellingTest();
        }

        [TestMethod]
        public void GetAllTest()
        {
            List<Bestelling> TestListBestelling = Context.GetAll();



            foreach (Bestelling TestBestelling in TestListBestelling)
            {
                if (TestBestelling == null)
                {
                    Assert.Fail();
                }
            }
            Assert.IsNotNull(TestListBestelling);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Bestelling TestBestelling = Context.GetById(1);

            Assert.IsNotNull(TestBestelling.Id);
        }

        [TestMethod]
        public void GetByIdTestFail()
        {
            Bestelling TestBestelling = Context.GetById(0);

            Assert.IsNull(TestBestelling.Id);
        }

        [TestMethod]
        public void InsertTest()
        {
            long TestLong = Context.Insert(new Bestelling() { Id = 1, Actief = true, KlantID = 1 });

            Assert.AreEqual(1, TestLong);
        }

        [TestMethod]
        public void InsertTestFail()
        {
            long TestLong = Context.Insert(null);

            Assert.AreEqual(0, TestLong);
        }

        [TestMethod]
        public void Bestellen()
        {
            List<Product> TestListProduct = new List<Product>();
            TestListProduct.Add(new Product() { Id = 1, Aantal = 3, CategorieId = 2, Actief = true, CategorieNaam = "Actie", Naam = "Morio", Prijs = "15", Tweedehands = false, Omschrijving = "lorum ipsum" });
            bool TestBool = Context.Bestellen(TestListProduct , 1);

            Assert.IsTrue(TestBool);
        }

        [TestMethod]
        public void BestellenFail()
        {
            List<Product> TestListProduct = new List<Product>();

            bool TestBool = Context.Bestellen(TestListProduct, 0);

            Assert.IsFalse(TestBool);
        }
    }
}
