using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MM264.Entities;

public partial class VendingMachine
{
    public int Id { get; set; }

    public double? Serial { get; set; }

    public string? Name { get; set; }
    [JsonIgnore]
    public int UserId { get; set; }

    public string? RfidCashCollection { get; set; }

    public string? Notes { get; set; }

    public string? Location { get; set; }

    public int? WorkMode { get; set; }

    public string? RfidLoading { get; set; }

    public int? Model { get; set; }

    public string? KitOnlineId { get; set; }

    public int? Company { get; set; }

    public int? CriticalThresholdTemplate { get; set; }

    public int? ServicePriority { get; set; }

    public int? Manager { get; set; }

    public int? Status { get; set; }

    public int? NotificationTemplate { get; set; }

    public string? WorkingHours { get; set; }

    public int? Engineer { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? InstallDate { get; set; }

    public int? Place { get; set; }

    public int? Operator { get; set; }

    public int? Technician { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public string? RfidService { get; set; }

    public string? Coordinates { get; set; }

    public string? TotalIncome { get; set; }

    public string? Timezone { get; set; }

    public virtual Company? CompanyNavigation { get; set; }

    public virtual CriticalThresholdTemplate? CriticalThresholdTemplateNavigation { get; set; }

    public virtual User? EngineerNavigation { get; set; }

    public virtual User? ManagerNavigation { get; set; }

    public virtual Model? ModelNavigation { get; set; }

    public virtual NotificationTemplate? NotificationTemplateNavigation { get; set; }

    public virtual Operator? OperatorNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<PaymenttypeVendingmachine> PaymenttypeVendingmachines { get; set; } = new List<PaymenttypeVendingmachine>();

    public virtual Place? PlaceNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ServicePriority? ServicePriorityNavigation { get; set; }

    public virtual Status? StatusNavigation { get; set; }

    public virtual User? TechnicianNavigation { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WorkMode? WorkModeNavigation { get; set; }
}
