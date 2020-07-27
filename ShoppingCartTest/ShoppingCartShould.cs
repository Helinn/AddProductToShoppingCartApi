using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        private readonly IReadOnlyList<ShoppingCart> _ShoppingCart;
        private readonly IReadOnlyList<Product> _Products;
        public ShoppingCartShould()
        {

            _ShoppingCart = new List<ShoppingCart>(){
                new ShoppingCart() { Id = "p1" , ProductId = "1", Amount = 2},
                new ShoppingCart() { Id = "p2" , ProductId = "2", Amount = 1},
                new ShoppingCart() { Id = "p3" , ProductId = "3", Amount = 3},
            };

            _Products = new List<Product>()
            {
                new Product() { Id = "1", Name = "Rose", Price = 5.00, AvailableQuantity = 5 },
                new Product() { Id = "2", Name = "Terrarium", Price = 4.00, AvailableQuantity = 10  },
                new Product() { Id = "3", Name = "Orchid", Price = 12.00, AvailableQuantity = 8  }
            };
        }
        [Test]
        public void AddProductToShoppingCart_Should_Return_True_If_Product_Available_In_Stock()
        {
            //Act
            var request = new AddToShoppingCartRequest{
                ProductId = ObjectId.GenerateNewId().ToString(),
                Amount = 2
            };
            var shoppingCartRepository = new Mock<IShoppingCartRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var service = new ShoppingCartService(productRepositoryMock.Object, shoppingCartRepository.Object );
           
            productRepositoryMock.Setup(x => x.GetByProductId(request.ProductId)).Returns(new Product() {
                                                                    Id = request.ProductId,
                                                                    Name = "Terrarium",
                                                                    Price = 4.00, 
                                                                    AvailableQuantity = 10  
                                                                    });
            // Act
            var response = service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsTrue(Convert.ToBoolean(response));
        }

        [Test]
        public void AddProductToShoppingCart_Should_Return_False_If_Product_Not_Available_In_Stock()
        {
            //Act
            var request = new AddToShoppingCartRequest{
                ProductId = ObjectId.GenerateNewId().ToString(),
                Amount = 2
            };
            var shoppingCartRepository = new Mock<IShoppingCartRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var service = new ShoppingCartService(productRepositoryMock.Object, shoppingCartRepository.Object );
            // Act
            productRepositoryMock.Setup(x => x.GetByProductId(request.ProductId)).Returns(new Product() {
                                                                    Id = request.ProductId,
                                                                    Name = "Terrarium",
                                                                    Price = 4.00, 
                                                                    AvailableQuantity = 0  
                                                                    });
            
            
            var response = service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsFalse(Convert.ToBoolean(response));
        }

        [Test]
        public void AddProductToShoppingCart_Should_Return_False_If_Product_Is_Null()
        {
            //Act
            var request = new AddToShoppingCartRequest{
                ProductId = ObjectId.GenerateNewId().ToString(),
                Amount = 2
            };
            var shoppingCartRepository = new Mock<IShoppingCartRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var service = new ShoppingCartService(productRepositoryMock.Object, shoppingCartRepository.Object );
           
            // Act
            var response = service.AddProductToShoppingCart(request);

            // Assert
            Assert.IsFalse(Convert.ToBoolean(response));
        }
    }
}
