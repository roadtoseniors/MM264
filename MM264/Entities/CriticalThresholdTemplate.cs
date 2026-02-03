using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class CriticalThresholdTemplate
{
    public int Id { get; set; }

    public string? CriticalThresholdTemplate1 { get; set; }
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
