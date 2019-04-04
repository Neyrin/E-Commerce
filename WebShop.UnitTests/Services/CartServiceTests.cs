using System;
using System.Collections.Generic;
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
    class CartServiceTests
    {
        private CartService cartService;

        [SetUp]
        public void SetUp()
        {
            this.cartService = new CartService(
             new CartRepository("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=EC1cmtq300;Integrated Security=True;Pooling=Falses"));
        }

        [Test]
        public void Get_returnsItemsFromDatabase()
        {
            //act
            var results = this.cartService.Get();
            //assert
            Assert.That(results.Count, Is.AtLeast(1));
        }

        //[Test]
        //public void Get_GivenId_ReturnsResultFromRepository()
        //{
        //    // Arrange
        //    // Act
        //    // Assert
        //}

        //[Test]
        //public void Add_GivenValidIds_CallsCartRepository_ThenReturnsTrue()
        //{
        //    //Arrange
        //    //Act
        //    //Assert
        //}
    }
}


