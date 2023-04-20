using Microsoft.AspNetCore.Mvc;
using Moq;
using RMLECommerceStore.Controllers;
using RMLECommerceStore.Models;
using RMLECommerceStore.Repository;
using RMLECommerceStore.ViewModels.Products;
using RMLECommerceStore.ViewModels;
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
        public void CanSendPaginationViewModel()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
new Product {ProductId = 1, Name = "P1"},
new Product {ProductId = 2, Name = "P2"},
new Product {ProductId = 3, Name = "P3"},
new Product {ProductId = 4, Name = "P4"},
new Product {ProductId = 5, Name = "P5"}
}).AsQueryable<Product>());
            // Arrange
            HomeController controller =
            new HomeController(mock.Object) { _pageSize = 3 };
            // Act

            ProductsListViewModel result =
            controller.Index(2)?.Result.ViewData.Model as ProductsListViewModel
            ?? new();

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }

        [Fact]
        public void CanPaginate()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
new Product {ProductId = 1, Name = "P1"},
new Product {ProductId = 2, Name = "P2"},
new Product {ProductId = 3, Name = "P3"},
new Product {ProductId = 4, Name = "P4"},
new Product {ProductId = 5, Name = "P5"}
}).AsQueryable());

            HomeController controller = new HomeController(mock.Object);
            controller._pageSize = 3;

            // Act
            ProductsListViewModel result =
controller.Index(2)?.Result.ViewData.Model as ProductsListViewModel ?? new();


            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
        }


        [Fact]
        public void CanUseRepository()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products)
                .Returns((new Product[] {
                    new Product {ProductId = 1, Name = "P1"},
                    new Product {ProductId = 2, Name = "P2"} })
                    .AsQueryable<Product>);

            HomeController homeController = new HomeController(mock.Object);

            // Act
            ProductsListViewModel result =
 homeController.Index()?.Result.ViewData.Model as ProductsListViewModel ?? new();


            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P1", prodArray[0].Name);
            Assert.Equal("P2", prodArray[1].Name);
        }
    }
}
