using E_commerce.Bll.Dtos.ProductDto;
using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Bll.Dtos.OrderProductDto;

public class GetOrderProductDto
{
    public long OrderProductId { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public GetProductDto GetProductDto { get; set; }
}
