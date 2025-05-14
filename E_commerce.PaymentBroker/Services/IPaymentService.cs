using E_commerce.PaymentBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.PaymentBroker.Services;

public interface IPaymentService
{
    Task ProcessPaymeTransaction(IPaymentTransactionRequestDto paymentTransactionRequestDto);
}
