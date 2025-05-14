using E_commerce.Bll.Dtos.ProductDto;
using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Bll.Dtos.CartProductDto;

public class GetCartProductDto
{
    public long CartProductId { get; set; }
    public int Quantity { get; set; }
    public long CartId { get; set; }
    public long ProductId { get; set; }
    public GetProductDto GetProductDto { get; set; }
}
