using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using NUnit;
using FakeItEasy;
using NUnit.Framework;
using WebShop.Repositories;
using WebShop.Services;
using WebShop.Models;
using System.Linq;

namespace WebShop.UnitTests.Services
{
    class ProductsServiceTests
    {
        private ProductsService productsService;

        [SetUp]
        public void SetUp()
        {
            this.productsService = new ProductsService(
             new ProductsRepository("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=EC1cmtq300;Integrated Security=True;Pooling=True"));
        }

        [Test]
        public void Get_returnsItemsFromDatabase()
        {
            //act
            var results = this.productsService.Get();
            //assert
            Assert.That(results.Count, Is.EqualTo(2));

            Assert.That(results[0].ProductId, Is.EqualTo(2));
            Assert.That(results[0].ProductName, Is.EqualTo("Highway tunnel"));
            Assert.That(results[0].ProductType, Is.EqualTo("Poster"));
            Assert.That(results[0].Price, Is.EqualTo(12));
        }
    }
}


