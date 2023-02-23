using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Data;

public partial class CarAdviceContext : DbContext
{
    public CarAdviceContext()
    {
    }

    public CarAdviceContext(DbContextOptions<CarAdviceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarAdviceDictionaryCountryCode> CarAdviceDictionaryCountryCodes { get; set; }

    public virtual DbSet<CarAdviceDictionaryCustomers> CarAdviceDictionaryCustomers { get; set; }

    public virtual DbSet<CarAdviceDictionaryLoadingPlace> CarAdviceDictionaryLoadingPlaces { get; set; }

    public virtual DbSet<CarAdviceDictionaryQuality> CarAdviceDictionaryQualities { get; set; }

    public virtual DbSet<CarAdviceDictionaryReason> CarAdviceDictionaryReasons { get; set; }

    public virtual DbSet<CarAdviceDictionarySecurityPerson> CarAdviceDictionarySecurityPersons { get; set; }

    public virtual DbSet<CarAdviceDictionaryStatus> CarAdviceDictionaryStatuses { get; set; }

    public virtual DbSet<CarAdviceDictionaryTruckType> CarAdviceDictionaryTruckTypes { get; set; }

    public virtual DbSet<CarAdviceMainTable> CarAdviceMainTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.17.80.141;Database=purchasing;User Id=purchasing;password=+I=wA9RlT6&tHuFUs*O7;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Polish_CI_AS");

        modelBuilder.Entity<CarAdviceDictionaryCountryCode>(entity =>
        {
            entity.HasIndex(e => e.Country, "IX_CarAdviceDictionaryCountryCodes").IsUnique();

            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.English).HasMaxLength(150);
            entity.Property(e => e.Polish).HasMaxLength(150);
        });

        modelBuilder.Entity<CarAdviceDictionaryCustomers>(entity =>
        {
            entity.HasIndex(e => e.Customer, "IX_CarAdviceDictionaryCustomers").IsUnique();

            entity.Property(e => e.ActiveFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.AddByUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Customer).HasMaxLength(50);
        });

        modelBuilder.Entity<CarAdviceDictionaryLoadingPlace>(entity =>
        {
            entity.ToTable("CarAdviceDictionaryLoadingPlace");

            entity.HasIndex(e => e.LoadingPlace, "IX_CarAdviceDictionaryLoadingPlace").IsUnique();

            entity.Property(e => e.ActiveFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.AddByUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("('System')");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LoadingPlace).HasMaxLength(30);
        });

        modelBuilder.Entity<CarAdviceDictionaryQuality>(entity =>
        {
            entity.ToTable("CarAdviceDictionaryQuality");

            entity.HasIndex(e => e.Quality, "IX_CarAdviceDictionaryQuality").IsUnique();

            entity.Property(e => e.Quality).HasMaxLength(30);
        });

        modelBuilder.Entity<CarAdviceDictionaryReason>(entity =>
        {
            entity.HasIndex(e => e.Code, "IX_CarAdviceDictionaryReasons").IsUnique();

            entity.Property(e => e.ActiveFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.AddByUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("('System')");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Code).HasMaxLength(100);
        });

        modelBuilder.Entity<CarAdviceDictionarySecurityPerson>(entity =>
        {
            entity.HasIndex(e => e.Security, "IX_CarAdviceDictionarySecurityPersons").IsUnique();

            entity.Property(e => e.ActiveFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.AddByUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("('System')");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ContactEmail).HasMaxLength(100);
            entity.Property(e => e.ContactMobile).HasMaxLength(50);
            entity.Property(e => e.Security).HasMaxLength(50);
        });

        modelBuilder.Entity<CarAdviceDictionaryStatus>(entity =>
        {
            entity.HasIndex(e => e.Status, "IX_CarAdviceDictionaryStatuses").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActiveFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.AddByUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("('System')");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<CarAdviceDictionaryTruckType>(entity =>
        {
            entity.HasIndex(e => e.Truck, "IX_CarAdviceDictionaryTruckTypes").IsUnique();

            entity.Property(e => e.ActiveFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.AddByUser)
                .HasMaxLength(50)
                .HasDefaultValueSql("('System')");
            entity.Property(e => e.AddTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Truck).HasMaxLength(50);
        });

        modelBuilder.Entity<CarAdviceMainTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TB");

            entity.ToTable("CarAdviceMainTable");

            entity.Property(e => e.AdviceDate).HasColumnType("datetime");
            entity.Property(e => e.Ata)
                .HasColumnType("datetime")
                .HasColumnName("ATA");
            entity.Property(e => e.CallBy).HasMaxLength(50);
            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.Destination)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DriverS).HasMaxLength(50);
            entity.Property(e => e.DriverWh)
                .HasMaxLength(150)
                .HasColumnName("DriverWH");
            entity.Property(e => e.EntryByS).HasMaxLength(50);
            entity.Property(e => e.EntryByWh)
                .HasMaxLength(50)
                .HasColumnName("EntryByWH");
            entity.Property(e => e.Etd)
                .HasColumnType("datetime")
                .HasColumnName("ETD");
            entity.Property(e => e.FgDelayReason)
                .HasMaxLength(100)
                .HasColumnName("FG_DelayReason");
            entity.Property(e => e.Forwarder).HasMaxLength(100);
            entity.Property(e => e.ForwarderInfo)
                .HasMaxLength(100)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.LeftTheDockTime).HasColumnType("datetime");
            entity.Property(e => e.PickingStatus).HasMaxLength(50);
            entity.Property(e => e.PickingTime).HasColumnType("datetime");
            entity.Property(e => e.Quality).HasMaxLength(30);
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.RemarksS).HasMaxLength(255);
            entity.Property(e => e.RemarksWh)
                .HasMaxLength(255)
                .HasColumnName("RemarksWH");
            entity.Property(e => e.ScannedTime).HasColumnType("datetime");
            entity.Property(e => e.Shipment).HasMaxLength(50);
            entity.Property(e => e.TpvEnterTime)
                .HasColumnType("datetime")
                .HasColumnName("TPV_EnterTime");
            entity.Property(e => e.TpvExitTime)
                .HasColumnType("datetime")
                .HasColumnName("TPV_ExitTime");
            entity.Property(e => e.TruckPlatesS).HasMaxLength(50);
            entity.Property(e => e.TruckPlatesWh)
                .HasMaxLength(100)
                .HasColumnName("TruckPlatesWH");
            entity.Property(e => e.TruckType).HasMaxLength(50);

            entity.HasOne(d => d.ClientNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Customer)
                .HasForeignKey(d => d.Client)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionaryCustomers");

            entity.HasOne(d => d.DestinationNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Country)
                .HasForeignKey(d => d.Destination)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionaryCountryCodes");

            entity.HasOne(d => d.EntryBySNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Security)
                .HasForeignKey(d => d.EntryByS)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionarySecurityPersons");

            entity.HasOne(d => d.FgDelayReasonNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.FgDelayReason)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionaryReasons");

            entity.HasOne(d => d.PickingStatusNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Status)
                .HasForeignKey(d => d.PickingStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionaryStatuses");

            entity.HasOne(d => d.QualityNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Quality)
                .HasForeignKey(d => d.Quality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionaryQuality");

            entity.HasOne(d => d.TruckTypeNavigation).WithMany(p => p.CarAdviceMainTables)
                .HasPrincipalKey(p => p.Truck)
                .HasForeignKey(d => d.TruckType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarAdviceMainTable_CarAdviceDictionaryTruckTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<SCMDWH.Shared.Models.CarAdviceMainPlanColumn> CarAdviceMainPlanComum { get; set; } = default!;
}
