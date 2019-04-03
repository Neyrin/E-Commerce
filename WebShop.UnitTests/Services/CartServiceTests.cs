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
        private ICartRepository cartRepository;
        private CartService newsService;

        [SetUp]
        public void SetUp()
        {
            this.cartRepository = A.Fake<ICartRepository>();
            this.newsService = new CartService(this.cartRepository);
        }

        [Test]
        public void Get_ReturnsResultFromRepository()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromRepository()
        {
            // Arrange
            // Act
            // Assert
        }

        [Test]
        public void Add_GivenValidIds_CallsCartRepository_ThenReturnsTrue()
        {
            //Arrange
            //Act
            //Assert
        }

        //[Test]
        //public void //Test delete here but how the fuck do I do that?()    
        //{
            //Arrange
            //Act
            //Assert
        //}
    }
}


