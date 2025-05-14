using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface IOrderRepository
{
    Task<long> InsertOrderAsync(Order order);
    Task<Order> SelectOrderByOrderId(long orderId);
    Task<List<Order>> SelectOrdersByCustomerId(long customerId);
}