using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.PaymentBroker.Models;

public class IPaymentTransactionRequestDto
{
    public decimal TotalPrice { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public Card Card { get; set; }
}
