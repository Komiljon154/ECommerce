using E_commerce.Dal;
using E_commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Services;

public class CustomerRepository : ICustomerRepository
{
    private readonly MainContext MainContext;

    public CustomerRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public Task DeleteCustomerByIdAsync(long customerId)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public async Task<Customer?> SelectCustomerByIdAsync(long customerId)
    {
        var customer = await MainContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        return customer;
    }
}
