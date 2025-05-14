using E_commerce.Bll.Dtos.OrderDto;

namespace E_commerce.Bll.Services;

public interface IOrderService
{
    Task<GetOrderDto> CheckOutOrderAsync(long customerId);
    Task MakePaymentAsync(long customerId);
}