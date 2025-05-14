using E_commerce.Bll.Dtos.CartProductDto;
using E_commerce.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Bll.Dtos.CartDto;

public class GetCartDto
{
    public long CartId { get; set; }
    public long CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public List<GetCartProductDto> GetCartProductDtos { get; set; }
}
