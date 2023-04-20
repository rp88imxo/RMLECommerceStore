using Microsoft.AspNetCore.Mvc;
using Moq;
using RMLECommerceStore.Controllers;
using RMLECommerceStore.Models;
using RMLECommerceStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMLECommerceStore.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void CanUseRepository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products)
                .Returns((new Product[] {
new Product {ProductId = 1, Name = "P1"},
new Product {ProductId = 2, Name = "P2"} }).AsQueryable<Product>);

            HomeController homeController = new HomeController(mock.Object);

            // Act
            IEnumerable<Product>? result =
(homeController.Index() as ViewResult)?.ViewData.Model
as IEnumerable<Product>;


            // Assert
            Product[] productArray = result?.ToArray() ?? Array.Empty<Product>();
            Assert.True(productArray.Length == 2);
            Assert.Equal("P1", productArray[0].Name);
            Assert.Equal("P2", productArray[1].Name);
        }
    }
}
