using E_commerce.Bll.Dtos.CartDto;
using E_commerce.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Server.Controllers;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartService CartService;

    public CartController(ICartService cartService)
    {
        CartService = cartService;
    }

    [HttpPost("add")]
    public async Task AddProduct(long customerId, long productId, int quantity)
        {
        await CartService.AddProductToCartAsync(customerId, productId, quantity);
    }

    [HttpGet("get")]
    public async Task<GetCartDto> GetCart(long customerId)
    {
        return await CartService.GetCartByCustomerId(customerId);
    }
}
