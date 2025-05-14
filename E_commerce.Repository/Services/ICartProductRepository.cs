using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface ICartProductRepository
{
    Task<long> InsertCartProductAsync(CartProduct cartProduct);
    Task DeleteCartProductByIdAsync(long cartProductId);
    Task<List<CartProduct>> SelectCartProductsByCartIdAsync(long cartId);
    Task UpdataCartProductAsync(CartProduct cartProduct);
}