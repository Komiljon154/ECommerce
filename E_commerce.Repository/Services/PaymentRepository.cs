using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Services;

public class PaymentRepository : IPaymentRepository
{
    public Task<long> InsertPaymentAsync(Payment payment)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePaymentAsync(Payment payment)
    {
        throw new NotImplementedException();
    }
}
