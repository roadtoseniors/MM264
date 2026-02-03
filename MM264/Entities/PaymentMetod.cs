using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class PaymentMetod
{
    public int Id { get; set; }

    public string? PaymentMethod { get; set; }
    [JsonIgnore]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
