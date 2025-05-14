using E_commerce.Bll.Dtos.CartDto;
using E_commerce.Bll.Dtos.CartProductDto;
using E_commerce.Bll.Dtos.ProductDto;
using E_commerce.Dal.Entities;
using E_commerce.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Bll.Services;

public class CartService : ICartService
{
    private readonly ICartRepository CartRepository;
    private readonly ICartProductRepository CartProductRepository;
    private readonly ICustomerRepository CustomerRepository;
    private readonly IProductRepository ProductRepository;

    public CartService(ICartRepository cartRepository,
        ICustomerRepository customerRepository,
        ICartProductRepository cartProductRepository,
        IProductRepository productRepository)
    {
        CartRepository = cartRepository;
        CustomerRepository = customerRepository;
        CartProductRepository = cartProductRepository;
        ProductRepository = productRepository;
    }

    public async Task AddProductToCartAsync(long customerId, long productId, int quantity)
    {
        var product = await ProductRepository.SelectProductByIdAsync(productId);
        if (product == null || product.StockQuantity < quantity) throw new Exception("Product is not enough");

        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);
        if (customer == null) throw new Exception("Customer not found in AddProductToCartAsync");

        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId);
        if (cart == null) cart = await CartRepository.CreateCartAsync(customerId);

        var cartProducts = await CartProductRepository.SelectCartProductsByCartIdAsync(cart.CartId); // must see the implementation of this method

        var productExists = cartProducts.Any(cP => cP.ProductId == productId);

        if (productExists is true)
        {
            var cartProduct = cartProducts.FirstOrDefault(cP => cP.ProductId == productId);
            if (quantity <= 0)
            {
                await CartProductRepository.DeleteCartProductByIdAsync(cartProduct.CartProductId);
            }
            else
            {
                cartProduct.Quantity = quantity;
                await CartProductRepository.UpdataCartProductAsync(cartProduct);
            }
        }
        else if (quantity > 0)
        {
            var newCartProduct = new CartProduct()
            {
                Quantity = quantity,
                ProductId = productId,
                CartId = cart.CartId,
            };

            await CartProductRepository.InsertCartProductAsync(newCartProduct);
        }

    }

    public async Task<GetCartDto> GetCartByCustomerId(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);
        if (customer == null) throw new Exception("Customer not found in GetCartByCustomerIdAsync");

        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId, true);
        if (cart is null)
        {
            throw new Exception("Cart is Empty");
        }

        var getCartDto = new GetCartDto()
        {
            CartId = cart.CartId,
            CustomerId = cart.CustomerId,
            CreatedAt = cart.CreatedAt,
            TotalPrice = cart.CartProducts.Sum(cP => cP.Quantity * cP.Product.Price),
            GetCartProductDtos = cart.CartProducts.Select(cP => ConvertCartProductToDto(cP)).ToList()
        };
        return getCartDto;
    }

    private GetCartProductDto ConvertCartProductToDto(CartProduct cartProduct)
    {
        var getCartProductDto = new GetCartProductDto()
        {
            CartProductId = cartProduct.CartProductId,
            Quantity = cartProduct.Quantity,
            CartId = cartProduct.CartId,
            ProductId = cartProduct.ProductId,
            GetProductDto = ConvertProductToDto(cartProduct.Product)
        };
        return getCartProductDto;
    }

    private GetProductDto ConvertProductToDto(Product product)
    {
        return new GetProductDto()
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageLink = product.ImageLink
        };
    }
}
