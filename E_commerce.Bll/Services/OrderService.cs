using E_commerce.Bll.Dtos.OrderDto;
using E_commerce.Bll.Dtos.OrderProductDto;
using E_commerce.Bll.Dtos.ProductDto;
using E_commerce.Dal.Entities;
using E_commerce.PaymentBroker.Models;
using E_commerce.PaymentBroker.Services;
using E_commerce.Repository.Services;

namespace E_commerce.Bll.Services;

public class OrderService : IOrderService
{
    private readonly ICartRepository CartRepository;
    private readonly ICustomerRepository CustomerRepository;
    private readonly ICardRepository CardRepository;
    private readonly IPaymentService PaymentSErvice;
    private readonly IOrderRepository OrderRepository;
    private readonly IOrederProductRepository OrderProductRepository;
    private readonly IProductRepository ProductRepository;

    public OrderService(ICartRepository cartRepository,
        ICustomerRepository customerRepository,
        ICardRepository cardRepository,
        IPaymentService paymentSErvice,
        IOrderRepository orderRepository,
        IOrederProductRepository orderProductRepository,
        IProductRepository productRepository)
    {
        CartRepository = cartRepository;
        CustomerRepository = customerRepository;
        CardRepository = cardRepository;
        PaymentSErvice = paymentSErvice;
        OrderRepository = orderRepository;
        OrderProductRepository = orderProductRepository;
        ProductRepository = productRepository;
    }

    public async Task MakePaymentAsync(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);
        if (customer == null) throw new Exception("Customer not found in MakePaymentAsync");

        var selectedCard = await CardRepository.SelectSelectedCardByCustomerId(customerId);
        if (selectedCard == null) throw new Exception("Card does not exist");

        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId, true);
        if (cart == null) throw new Exception("Cart is empty, can not be checked our");

        var paymentTransactionRequestDto = new IPaymentTransactionRequestDto()
        {
            TotalPrice = cart.CartProducts.Sum(cP => cP.Quantity * cP.Product.Price),
            CustomerPhoneNumber = customer.PhoneNumber,
            Card = selectedCard
        };

        await PaymentSErvice.ProcessPaymeTransaction(paymentTransactionRequestDto);

        var order = new Order()
        {
            CustomerId = customerId,
            CreatedAt = DateTime.UtcNow,
            TotalAmount = cart.CartProducts.Sum(cP => cP.Quantity * cP.Product.Price),
            Discount = 0,
            DiscountPercentage = 0,
            ServicePrice = 0,
            StatusId = 6,
        };

        var orderId = await OrderRepository.InsertOrderAsync(order);

        var orderProducts = cart.CartProducts.Select(c => new OrderProduct()
        {
            OrderId = orderId,
            ProductId = c.ProductId,
            Quantity = c.Quantity,
        }).ToList();

        await OrderProductRepository.InsertOrderProducts(orderProducts);

        foreach (var cartProduct in cart.CartProducts)
        {
            var product = cartProduct.Product;
            product.StockQuantity -= cartProduct.Quantity;
            await ProductRepository.UpdateProductAsync(product);
        }

        await CartRepository.ClearCartAsync(customerId);
    }

    public async Task<GetOrderDto> CheckOutOrderAsync(long customerId)
    {
        var customer = await CustomerRepository.SelectCustomerByIdAsync(customerId);
        if (customer == null) throw new Exception("Customer not found in CheckOutOrderAsync");

        var cart = await CartRepository.GetCartByCustomerIdAsync(customerId, true);
        if (cart == null) throw new Exception("Cart is empty, can not be checked out");

        var getOrderDto = new GetOrderDto()
        {
            CustomerId = customerId,
            CreatedAt = cart.CreatedAt,
            TotalAmount = cart.CartProducts.Sum(cP => cP.Quantity * cP.Product.Price),
            Discount = 0,
            DiscountPercentage = 0,
            ServicePrice = 0,
            OrderStatus = "Pending",
            GetOrderProductDtos = cart.CartProducts.Select(cP => ConvertCartProductToOrderProductDto(cP)).ToList(),
        };
        return getOrderDto;
    }



    private GetOrderProductDto ConvertCartProductToOrderProductDto(CartProduct cartProduct)
    {
        var getOrderProductDto = new GetOrderProductDto()
        {
            Quantity = cartProduct.Quantity,
            ProductId = cartProduct.ProductId,
            GetProductDto = ConvertProductToDto(cartProduct.Product)
        };

        return getOrderProductDto;
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
