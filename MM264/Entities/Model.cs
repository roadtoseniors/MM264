using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class Model
{
    public int Id { get; set; }

    public string? Model1 { get; set; }
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachines { get; set; } = new List<VendingMachine>();
}
