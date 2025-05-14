using E_commerce.Dal;
using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Services;

public class OrederProductRepository : IOrederProductRepository
{
    private readonly MainContext MainContext;

    public OrederProductRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task InsertOrderProducts(List<OrderProduct> orderProducts)
    {
        await MainContext.OrderProducts.AddRangeAsync(orderProducts);
        await MainContext.SaveChangesAsync();
    }
}
