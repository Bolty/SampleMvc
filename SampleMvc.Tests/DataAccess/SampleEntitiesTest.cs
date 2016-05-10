using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace SampleMvc.Tests.DataAccess
{
    // Unit tests for the additional functionality provided
    // to the SampleEntities class to fulfill IRepository
    [TestClass]
    public class SampleEntitiesTest
    {
        private SampleEntities sut;

        public SampleEntitiesTest()
        {
            sut = new SampleEntities();
            sut.spClearAllData();
            sut.spSetReferenceData();
        }

        [TestMethod]
        public void GetSingleEntity()
        {
            var result = sut.Get<Category>(1);
            Assert.AreEqual("Books", result.Name);
        }

        [TestMethod]
        public void GetAllEntitiesOfType()
        {
            var result = sut.Get<Category>();
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void AddEntity()
        {
            var product = GetTestProduct();
            var result = sut.Add(product);
            Assert.AreNotSame(0, product.ProductId);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            var product = GetTestProduct();
            var id = sut.Add(product).ProductId;
            sut.Delete(product);

            var ghost = sut.Get<Product>(id);
            Assert.IsNull(ghost);
        }

        [TestMethod]
        public void EditEntity()
        {
            var product = GetTestProduct();
            product = sut.Add(product);
            product.Name = "Smile";
            var id = sut.Edit(product).ProductId;

            var editedProduct = sut.Get<Product>(id);
            Assert.AreEqual("Smile", editedProduct.Name);
        }

        private Product GetTestProduct()
        {
            var category = sut.Get<Category>().FirstOrDefault(x => x.Name == "CDs");
            return new Product() { Name = "Pet Sounds", Category = category };
        }
    }
}
