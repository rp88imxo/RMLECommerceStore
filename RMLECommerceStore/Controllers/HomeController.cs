using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMLECommerceStore.Repository;
using RMLECommerceStore.ViewModels.Products;

namespace RMLECommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository storeRepository;
        public int _pageSize = 4;

        public HomeController(
            IStoreRepository storeRepository
            )
        {
            this.storeRepository = storeRepository;
        }


        // GET
        public async Task<ViewResult> Index(int pageNumber = 1)
        {
            var pagedQuery = storeRepository.Products
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * _pageSize)
                .Take(_pageSize);

            var viewModel = new ProductsListViewModel()
            {
                Products = pagedQuery,
                PagingInfo = new ViewModels.PagingInfo
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = _pageSize,
                    TotalItems = await storeRepository.Products.CountAsync()
                }
            };

            return View(viewModel);
        }
    }
}