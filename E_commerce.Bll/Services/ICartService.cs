using E_commerce.Bll.Dtos.CartDto;

namespace E_commerce.Bll.Services;

public interface ICartService
{
    Task AddProductToCartAsync(long customerId, long productId, int quantity);
    Task<GetCartDto> GetCartByCustomerId(long customerId);
}