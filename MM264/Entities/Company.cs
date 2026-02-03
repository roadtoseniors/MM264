using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string? Company1 { get; set; }
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
