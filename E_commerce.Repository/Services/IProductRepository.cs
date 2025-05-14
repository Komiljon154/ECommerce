using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface IProductRepository
{
    Task<long> InsertProductAsync(Product product);
    Task<Product?> SelectProductByIdAsync(long productId);
    Task UpdateProductAsync(Product product);
}