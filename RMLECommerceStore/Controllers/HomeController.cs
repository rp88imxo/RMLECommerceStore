using Microsoft.AspNetCore.Mvc;
using RMLECommerceStore.Repository;

namespace RMLECommerceStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository storeRepository;

        public HomeController(
            IStoreRepository storeRepository
            )
        {
            this.storeRepository = storeRepository;
        }


        // GET
        public IActionResult Index()
        {
            return View(storeRepository.Products);
        }
    }
}