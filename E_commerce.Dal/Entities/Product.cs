using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Dal.Entities;

public class Product
{
    [Key]
    public long ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageLink { get; set; }
    public List<CartProduct> CartProducts { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}
