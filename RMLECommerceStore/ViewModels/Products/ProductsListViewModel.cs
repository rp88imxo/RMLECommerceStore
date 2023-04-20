using RMLECommerceStore.Models;

namespace RMLECommerceStore.ViewModels.Products
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = null!;
        public PagingInfo PagingInfo { get; set; } = null!;
    }
}
