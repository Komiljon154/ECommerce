using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface IPaymentRepository
{
    Task<long> InsertPaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
}