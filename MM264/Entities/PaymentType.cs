using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class PaymentType
{
    public int Id { get; set; }

    public string? PaymentType1 { get; set; }
    [JsonIgnore]
    public virtual ICollection<PaymenttypeVendingmachine> PaymenttypeVendingmachines { get; set; } = new List<PaymenttypeVendingmachine>();
}
