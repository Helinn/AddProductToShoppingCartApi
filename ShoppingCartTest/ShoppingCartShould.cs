using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingCartApi.Controllers;
using ShoppingCartApi.Models;
using ShoppingCartApi.Repositories;
using ShoppingCartApi.Requests;
using ShoppingCartApi.Services;

namespace ShoppingCartTest
{
    [TestFixture]
    public class ShoppingCartShould
    {
        ShoppingCartController _controller;
        IShoppingCartService _service;

        public ShoppingCartShould()
        {
            _service = new BasketServiceForTest();
            _controller = new ShoppingCartController(_service);
        }
        [Test]
        public void GetAll_Should_Return_Product_Count()
        {
            // Act
            var okResult = _controller.GetAll();

            // Assert
            Assert.AreEqual(3,okResult.Count);
        }

        // [Test]
        //  public void AddItemToBasket_ReturnsBadRequest_If_Request_Not_Valid()
        // {
        //     // Arrange
        //     var request = new AddToShoppingCartRequest{
        //         ProductId = "",
        //         Amount = 0
        //     };
        //     // Act
        //     var response = _service.AddProductToShoppingCart(request);


        //     // Assert
        //     Assert.IsInstanceOf<BadRequestObjectResult>(badResponse);
        // }

        [Test]
        public void AddItemToShoppingCart_ReturnsItem_If_Product_Could_Add()
        {
            // Arrange 
            var request = new AddToShoppingCartRequest{
                ProductId = "1",
                Amount = 2
            };
            // Act
            var response = _service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public void AddItemToShoppingCart_ReturnsItem_If_There_Is_No_Product()
        {
            // Arrange
            var request = new AddToShoppingCartRequest{
                ProductId = "6",
                Amount = 2
            };
            // Act
            var response = _service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsFalse(Convert.ToBoolean(response));
        }

        [Test]
        public void AddItemToShoppingCart_ReturnsTrue_If_Product_In_Stock()
        {
            // Arrange
            var request = new AddToShoppingCartRequest{
                ProductId = "1",
                Amount = 2
            };
            var shoppingCartMock = new Mock<IShoppingCartRepository>();
            var productMock = new Mock<IProductRepository>();
            productMock.Setup(productMock => productMock.GetByProductId("2")).Returns(new Product() { Id = "2", Name = "Terrarium", Price = 4.00, AvailableQuantity = 10  });
            //mock.Setup(add => add.AddProductToShoppingCart(request)).Returns(false);
            // Act
            var response = _service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsTrue(Convert.ToBoolean(response));
        }

                [Test]
        public void AddItemToShoppingCart_ReturnsFalse_If_Product_In_Stock()
        {
            // Arrange
            var request = new AddToShoppingCartRequest{
                ProductId = "1",
                Amount = 2
            };
            // Act
            var response = _service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsTrue(Convert.ToBoolean(response));
        }
        
    }
}
