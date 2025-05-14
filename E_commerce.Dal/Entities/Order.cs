using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Dal.Entities;

public class Order
{
    [Key]
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public byte DiscountPercentage { get; set; }
    public decimal ServicePrice { get; set; }
    public int StatusId { get; set; }
    public Customer Customer { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
    public List<Payment> Payments { get; set; }
}
