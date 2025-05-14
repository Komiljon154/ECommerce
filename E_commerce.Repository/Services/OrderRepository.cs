using E_commerce.Dal;
using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Services;

public class OrderRepository : IOrderRepository
{
    private readonly MainContext MainContext;

    public OrderRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> InsertOrderAsync(Order order)
    {
        await MainContext.Orders.AddAsync(order);
        await MainContext.SaveChangesAsync();
        return order.OrderId;
    }

    public Task<Order> SelectOrderByOrderId(long orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> SelectOrdersByCustomerId(long customerId)
    {
        throw new NotImplementedException();
    }
}
