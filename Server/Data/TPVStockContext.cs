using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using SCMDWH.Shared.Models;


namespace SCMDWH.Server.Data
{
    public partial class TPVstockContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public TPVstockContext(DbContextOptions<TPVstockContext> options)
           : base(options)
        {
        }

        public virtual Microsoft.EntityFrameworkCore.DbSet<EshippingContainers> EshippingContainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EshippingContainers>(entity =>
            {
                entity.HasIndex(e => e.DeliveryNote2, "EshippingContainers_IND1").HasFillFactor(85);

                entity.HasIndex(e => e.Wmsimported, "EshippingContainers_IND2").HasFillFactor(85);

                entity.HasIndex(e => new { e.PickUpDateTime, e.Eta }, "Turbo_Index__01__2023_06_07").HasFillFactor(85);

                entity.Property(e => e.Ata)
                    .HasColumnType("datetime")
                    .HasColumnName("ATA");
                entity.Property(e => e.Atd)
                    .HasColumnType("datetime")
                    .HasColumnName("ATD");
                entity.Property(e => e.CallTruckStatus).HasMaxLength(100);
                entity.Property(e => e.Carrier).HasMaxLength(100);
                entity.Property(e => e.CntrType).HasMaxLength(100);
                entity.Property(e => e.ContainerNo).HasMaxLength(100);
                entity.Property(e => e.DeliveryNote1).HasMaxLength(100);
                entity.Property(e => e.DeliveryNote2).HasMaxLength(100);
                entity.Property(e => e.DestName).HasMaxLength(100);
                entity.Property(e => e.Eta)
                    .HasColumnType("datetime")
                    .HasColumnName("ETA");
                entity.Property(e => e.Etd)
                    .HasColumnType("datetime")
                    .HasColumnName("ETD");
                entity.Property(e => e.HouseDl)
                    .HasMaxLength(100)
                    .HasColumnName("HouseDL");
                entity.Property(e => e.MasterBl)
                    .HasMaxLength(100)
                    .HasColumnName("MasterBL");
                entity.Property(e => e.PickUpDateTime).HasColumnType("datetime");
                entity.Property(e => e.ProductType).HasMaxLength(100);
                entity.Property(e => e.ShipmentId).HasMaxLength(100);
                entity.Property(e => e.Status).HasMaxLength(100);
                entity.Property(e => e.TransMode).HasMaxLength(100);
                entity.Property(e => e.TruckerNm1).HasMaxLength(100);
                entity.Property(e => e.WmsimportTime)
                    .HasColumnType("datetime")
                    .HasColumnName("WMSimportTime");
                entity.Property(e => e.Wmsimported).HasColumnName("WMSimported");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
