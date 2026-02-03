using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? SerialNumber { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public double? MinStock { get; set; }
    [JsonIgnore]
    public int? VendingMachineId { get; set; }

    public string? Description { get; set; }

    public double? QuantityAvailable { get; set; }

    public double? SalesTrend { get; set; }
    [JsonIgnore]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual VendingMachine? VendingMachine { get; set; }
}
