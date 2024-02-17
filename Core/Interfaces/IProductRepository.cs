using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        // It is going to return a Task of type Product
        Task<Product> GetProductByIdAsync(int id);
        // We could use List gere, but we have been more specific with IReadOnlyList
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}