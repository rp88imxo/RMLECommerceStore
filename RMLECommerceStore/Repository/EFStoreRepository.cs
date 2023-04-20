using RMLECommerceStore.Database;
using RMLECommerceStore.Models;

namespace RMLECommerceStore.Repository
{
    public class EFStoreRepository : IStoreRepository
    {
        public readonly StoreDbContext storeDbContext;
        public EFStoreRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public IQueryable<Product> Products => storeDbContext.Products;
    }
}
