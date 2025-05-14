using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Dal.Entities;

public class Card
{
    [Key]
    public long CardId { get; set; }
    public long CustomerId { get; set; }
    public string Number { get; set; }
    public string HolderName { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public int? Cvv { get; set; }
    public bool SelectedForPayment { get; set; }
    public Customer Customer { get; set; }
}
