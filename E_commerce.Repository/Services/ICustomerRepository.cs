using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface ICustomerRepository
{
    Task<long> InsertCustomerAsync(Customer customer);
    Task<Customer?> SelectCustomerByIdAsync(long customerId);
    Task DeleteCustomerByIdAsync(long customerId);
}