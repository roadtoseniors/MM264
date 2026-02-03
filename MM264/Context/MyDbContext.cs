using System;
using System.Collections.Generic;
using MM264.Entities;
using Microsoft.EntityFrameworkCore;

namespace MM264.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CriticalThresholdTemplate> CriticalThresholdTemplates { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<PaymentMetod> PaymentMetods { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<PaymenttypeVendingmachine> PaymenttypeVendingmachines { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<ServicePriority> ServicePriorities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VendingMachine> VendingMachines { get; set; }

    public virtual DbSet<WorkMode> WorkModes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-AB4C90S;Initial Catalog=VendingDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("company$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Company1)
                .HasMaxLength(255)
                .HasColumnName("company");
        });

        modelBuilder.Entity<CriticalThresholdTemplate>(entity =>
        {
            entity.ToTable("critical_threshold_template$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CriticalThresholdTemplate1)
                .HasMaxLength(255)
                .HasColumnName("critical_threshold_template");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.ToTable("model$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Model1)
                .HasMaxLength(255)
                .HasColumnName("model");
        });

        modelBuilder.Entity<NotificationTemplate>(entity =>
        {
            entity.ToTable("notification_template$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NotificationTemplate1)
                .HasMaxLength(255)
                .HasColumnName("notification_template");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.ToTable("operator$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Operator1)
                .HasMaxLength(255)
                .HasColumnName("operator");
        });

        modelBuilder.Entity<PaymentMetod>(entity =>
        {
            entity.ToTable("payment_metod$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(255)
                .HasColumnName("payment_method");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("payment_type$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymentType1)
                .HasMaxLength(255)
                .HasColumnName("payment_type");
        });

        modelBuilder.Entity<PaymenttypeVendingmachine>(entity =>
        {
            entity.ToTable("paymenttype_vendingmachine$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymenttypeId).HasColumnName("Paymenttype_ID");
            entity.Property(e => e.VendingmachineId).HasColumnName("Vendingmachine_ID");

            entity.HasOne(d => d.Paymenttype).WithMany(p => p.PaymenttypeVendingmachines)
                .HasForeignKey(d => d.PaymenttypeId)
                .HasConstraintName("FK_paymenttype_vendingmachine$_payment_type$");

            entity.HasOne(d => d.Vendingmachine).WithMany(p => p.PaymenttypeVendingmachines)
                .HasForeignKey(d => d.VendingmachineId)
                .HasConstraintName("FK_paymenttype_vendingmachine$_vending_machines$");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.ToTable("place$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Place1)
                .HasMaxLength(255)
                .HasColumnName("place");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MinStock).HasColumnName("min_stock");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.QuantityAvailable).HasColumnName("quantity_available");
            entity.Property(e => e.SalesTrend).HasColumnName("sales_trend");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(255)
                .HasColumnName("serial_number");
            entity.Property(e => e.VendingMachineId).HasColumnName("vending_machine_id");

            entity.HasOne(d => d.VendingMachine).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendingMachineId)
                .HasConstraintName("FK_products$_vending_machines$");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("role$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Role1)
                .HasMaxLength(255)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("sales$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.PaymentMethodNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PaymentMethod)
                .HasConstraintName("FK_sales$_payment_metod$");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_sales$_products$");
        });

        modelBuilder.Entity<ServicePriority>(entity =>
        {
            entity.ToTable("service_priority$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ServicePriority1)
                .HasMaxLength(255)
                .HasColumnName("service_priority");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("status$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Status1)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsEngineer).HasColumnName("is_engineer");
            entity.Property(e => e.IsManager).HasColumnName("is_manager");
            entity.Property(e => e.IsOperator).HasColumnName("is_operator");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(255)
                .HasColumnName("serial_number");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_users$_role$");
        });

        modelBuilder.Entity<VendingMachine>(entity =>
        {
            entity.ToTable("vending_machines$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Company).HasColumnName("company");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(255)
                .HasColumnName("coordinates");
            entity.Property(e => e.CriticalThresholdTemplate).HasColumnName("critical_threshold_template");
            entity.Property(e => e.Engineer).HasColumnName("engineer");
            entity.Property(e => e.InstallDate)
                .HasColumnType("datetime")
                .HasColumnName("install_date");
            entity.Property(e => e.KitOnlineId)
                .HasMaxLength(255)
                .HasColumnName("kit_online_id");
            entity.Property(e => e.LastMaintenanceDate)
                .HasColumnType("datetime")
                .HasColumnName("last_maintenance_date");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Manager).HasColumnName("manager");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.NotificationTemplate).HasColumnName("notification_template");
            entity.Property(e => e.Operator).HasColumnName("operator");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.RfidCashCollection)
                .HasMaxLength(255)
                .HasColumnName("rfid_cash_collection");
            entity.Property(e => e.RfidLoading)
                .HasMaxLength(255)
                .HasColumnName("rfid_loading");
            entity.Property(e => e.RfidService)
                .HasMaxLength(255)
                .HasColumnName("rfid_service");
            entity.Property(e => e.Serial).HasColumnName("serial");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(255)
                .HasColumnName("serial_number");
            entity.Property(e => e.ServicePriority).HasColumnName("service_priority");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Technician).HasColumnName("technician");
            entity.Property(e => e.Timezone)
                .HasMaxLength(255)
                .HasColumnName("timezone");
            entity.Property(e => e.TotalIncome)
                .HasMaxLength(255)
                .HasColumnName("total_income");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkMode).HasColumnName("work_mode");
            entity.Property(e => e.WorkingHours)
                .HasMaxLength(255)
                .HasColumnName("working_hours");

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.Company)
                .HasConstraintName("FK_vending_machines$_company$");

            entity.HasOne(d => d.CriticalThresholdTemplateNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.CriticalThresholdTemplate)
                .HasConstraintName("FK_vending_machines$_critical_threshold_template$");

            entity.HasOne(d => d.EngineerNavigation).WithMany(p => p.VendingMachineEngineerNavigations)
                .HasForeignKey(d => d.Engineer)
                .HasConstraintName("FK_vending_machines$_users$2");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.VendingMachineManagerNavigations)
                .HasForeignKey(d => d.Manager)
                .HasConstraintName("FK_vending_machines$_users$1");

            entity.HasOne(d => d.ModelNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.Model)
                .HasConstraintName("FK_vending_machines$_model$");

            entity.HasOne(d => d.NotificationTemplateNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.NotificationTemplate)
                .HasConstraintName("FK_vending_machines$_notification_template$");

            entity.HasOne(d => d.OperatorNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.Operator)
                .HasConstraintName("FK_vending_machines$_operator$");

            entity.HasOne(d => d.PlaceNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.Place)
                .HasConstraintName("FK_vending_machines$_place$");

            entity.HasOne(d => d.ServicePriorityNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.ServicePriority)
                .HasConstraintName("FK_vending_machines$_service_priority$");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_vending_machines$_status$");

            entity.HasOne(d => d.TechnicianNavigation).WithMany(p => p.VendingMachineTechnicianNavigations)
                .HasForeignKey(d => d.Technician)
                .HasConstraintName("FK_vending_machines$_users$3");

            entity.HasOne(d => d.User).WithMany(p => p.VendingMachineUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_vending_machines$_users$");

            entity.HasOne(d => d.WorkModeNavigation).WithMany(p => p.VendingMachines)
                .HasForeignKey(d => d.WorkMode)
                .HasConstraintName("FK_vending_machines$_work_mode$");
        });

        modelBuilder.Entity<WorkMode>(entity =>
        {
            entity.ToTable("work_mode$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.WorkMode1)
                .HasMaxLength(255)
                .HasColumnName("work_mode");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
