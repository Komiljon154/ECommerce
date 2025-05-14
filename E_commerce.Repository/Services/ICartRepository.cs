using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface ICartRepository
{
    Task<Cart> CreateCartAsync(long customerId);
    Task ClearCartAsync(long customerId);
    Task<Cart?> GetCartByCustomerIdAsync(long customerId, bool includeCartProducts = false);
    Task DeleteCartAsync(long customerId);
    Task UpdateCartAsync(Cart cart);
}