using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Dal.Entities;

public class OrderStatus
{
    [Key]
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public List<Order> Orders { get; set; }
}