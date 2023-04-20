using RMLECommerceStore.Models;

namespace RMLECommerceStore.Repository
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
