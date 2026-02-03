using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? FullName { get; set; }

    public double? IsManager { get; set; }

    public double? IsEngineer { get; set; }

    public string? Phone { get; set; }

    public string? SerialNumber { get; set; }

    public double? IsOperator { get; set; }

    public int? Role { get; set; }

    public double? Password { get; set; }

    public virtual Role? RoleNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachineEngineerNavigations { get; set; } = new List<VendingMachine>();
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachineManagerNavigations { get; set; } = new List<VendingMachine>();
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachineTechnicianNavigations { get; set; } = new List<VendingMachine>();
    [JsonIgnore]
    public virtual ICollection<VendingMachine> VendingMachineUsers { get; set; } = new List<VendingMachine>();
}
