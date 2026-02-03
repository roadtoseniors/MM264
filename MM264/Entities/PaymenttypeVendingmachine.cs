using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class PaymenttypeVendingmachine
{
    public int Id { get; set; }
    [JsonIgnore]
    public int? VendingmachineId { get; set; }
    [JsonIgnore]
    public int? PaymenttypeId { get; set; }

    public virtual PaymentType? Paymenttype { get; set; }

    public virtual VendingMachine? Vendingmachine { get; set; }
}
