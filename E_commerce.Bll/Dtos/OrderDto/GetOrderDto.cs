using E_commerce.Bll.Dtos.OrderProductDto;
using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Bll.Dtos.OrderDto;

public class GetOrderDto
{
    public long OrderId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public byte DiscountPercentage { get; set; }
    public decimal ServicePrice { get; set; }
    public string OrderStatus { get; set; }
    public List<GetOrderProductDto> GetOrderProductDtos { get; set; }
}
