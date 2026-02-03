using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class Sale
{
    public int Id { get; set; }

    public DateTime? Timestamp { get; set; }
    [JsonIgnore]
    public int? ProductId { get; set; }

    public double TotalPrice { get; set; }

    public double? Quantity { get; set; }

    public int? PaymentMethod { get; set; }

    public virtual PaymentMetod? PaymentMethodNavigation { get; set; }

    public virtual Product? Product { get; set; }
}
