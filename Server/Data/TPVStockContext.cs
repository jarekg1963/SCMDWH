using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SCMDWH.Shared.Models;

namespace SCMDWH.Server.Data;

public partial class TPVStockContext : DbContext
{
    public TPVStockContext()
    {
    }

    public TPVStockContext(DbContextOptions<TPVStockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrier> Carriers { get; set; }

    public virtual DbSet<Cmrdoc> Cmrdocs { get; set; }

    public virtual DbSet<Cmritem> Cmritems { get; set; }

    public virtual DbSet<DailyProductionPlanExcel> DailyProductionPlanExcels { get; set; }

    public virtual DbSet<EshippingContainer> EshippingContainers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPallet> ProductPallets { get; set; }

    public virtual DbSet<Recipient> Recipients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.CarrierId).HasName("PK__Carriers__7C8480AE");

            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Adress1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Adress2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contact1)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Contact2)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Contact3)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fax2)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Fax3)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nip)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NIP");
            entity.Property(e => e.PartyType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone2)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone3)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.ShortName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Www)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WWW");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cmrdoc>(entity =>
        {
            entity.HasKey(e => e.CmrdocId).HasName("PK__CMRdoc__769BB83052CF095B");

            entity.ToTable("CMRdoc");

            entity.HasIndex(e => e.Cmrnumber, "CMRdoc_ind1")
                .IsUnique()
                .HasFillFactor(85);

            entity.HasIndex(e => e.Seal1, "CMRdoc_ind2").HasFillFactor(85);

            entity.HasIndex(e => e.Seal2, "CMRdoc_ind3").HasFillFactor(85);

            entity.HasIndex(e => e.Consigment, "CMRdoc_ind4").HasFillFactor(85);

            entity.Property(e => e.CmrdocId).HasColumnName("CMRdocId");
            entity.Property(e => e.AttachedDocs)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CarriageInstruction)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.CmrcarrierId1).HasColumnName("CMRCarrierID1");
            entity.Property(e => e.CmrcarrierId2).HasColumnName("CMRCarrierID2");
            entity.Property(e => e.Cmrdate)
                .HasColumnType("datetime")
                .HasColumnName("CMRdate");
            entity.Property(e => e.Cmrnumber).HasColumnName("CMRNumber");
            entity.Property(e => e.Consigment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConsigneeId).HasColumnName("ConsigneeID");
            entity.Property(e => e.ContainerNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DeliveryPlaceId).HasColumnName("DeliveryPlaceID");
            entity.Property(e => e.Driver)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EShpReadyToReport).HasColumnName("E_Shp_ReadyToReport");
            entity.Property(e => e.EstablishedDate).HasColumnType("datetime");
            entity.Property(e => e.EstablishedPlace)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastReportResultMessage)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.LastReportTime).HasColumnType("datetime");
            entity.Property(e => e.LoadingDate).HasColumnType("datetime");
            entity.Property(e => e.LoadingPlaceId).HasColumnName("LoadingPlaceID");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PrintTime).HasColumnType("datetime");
            entity.Property(e => e.PrintUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationsNo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.Seal1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Seal2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SenderInstruction)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TruckServiceBscode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TruckServiceBSCODE");
            entity.Property(e => e.TruckServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TruckType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Tstamp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("TStamp");
        });

        modelBuilder.Entity<Cmritem>(entity =>
        {
            entity.HasKey(e => e.CmritemId).HasName("PK__CMRItems__25FB978D");

            entity.ToTable("CMRItems");

            entity.HasIndex(e => e.CmrdocId, "CMRitems_ind1").HasFillFactor(85);

            entity.Property(e => e.CmritemId).HasColumnName("CMRItemId");
            entity.Property(e => e.CmrdocId).HasColumnName("CMRdocId");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NatureOfGoods)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Packing)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Quantity).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StatisticalNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Volume).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.Weight).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.WeightUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DailyProductionPlanExcel>(entity =>
        {
            entity.HasKey(e => e.WorkOrderNo);

            entity.ToTable("DailyProductionPlanExcel");

            entity.Property(e => e.WorkOrderNo).HasMaxLength(100);
            entity.Property(e => e.Ctn)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Customer)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CycleTime).IsUnicode(false);
            entity.Property(e => e.EndD)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EndH)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.InsertTime).HasColumnType("datetime");
            entity.Property(e => e.Invoice).IsUnicode(false);
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.LhgStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LHG_Status");
            entity.Property(e => e.LineName)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MinCt)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("MinCT");
            entity.Property(e => e.OryginalCtnFromFile)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Pcsh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PCSH");
            entity.Property(e => e.SlImportedToWms).HasColumnName("SL_ImportedToWMS");
            entity.Property(e => e.SlStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SL_Status");
            entity.Property(e => e.SsbPn).IsUnicode(false);
            entity.Property(e => e.StartD)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartH)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Team)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TpvModel)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.TunerAssy).IsUnicode(false);
            entity.Property(e => e.TunerWo).IsUnicode(false);
            entity.Property(e => e.WoActivityStatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.WoEndTime).HasColumnType("datetime");
            entity.Property(e => e.WoStartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EshippingContainer>(entity =>
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

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.SkdpartNo);

            entity.HasIndex(e => e.ProductCode, "Products_ind1").HasFillFactor(85);

            entity.HasIndex(e => e.CustomerNo, "Products_ind2").HasFillFactor(85);

            entity.HasIndex(e => new { e.ProductCode, e.Active }, "Turbo_Index__01__2015_11_17").HasFillFactor(85);

            entity.HasIndex(e => e.Active, "Turbo_Index__02__2023_07_05").HasFillFactor(85);

            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Depth).HasColumnType("decimal(16, 3)");
            entity.Property(e => e.Height).HasColumnType("decimal(16, 3)");
            entity.Property(e => e.MatWeight).HasColumnType("decimal(16, 5)");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mrpcontroller)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MRPController");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TpvisionWeight)
                .HasColumnType("decimal(16, 5)")
                .HasColumnName("TPVisionWeight");
            entity.Property(e => e.TpvisionWeightUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TPVisionWeightUnit");
            entity.Property(e => e.UnitOfDimension)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WeightUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Width).HasColumnType("decimal(16, 3)");
        });

        modelBuilder.Entity<ProductPallet>(entity =>
        {
            entity.HasKey(e => e.ProductPalletId).HasName("PK__ProductP__384831BA2C3E237C");

            entity.HasIndex(e => new { e.SkdpartNo, e.PalletPn }, "ProductPallets_IND1")
                .IsUnique()
                .HasFillFactor(85);

            entity.HasIndex(e => e.SkdpartNo, "ProductPallets_IND2").HasFillFactor(85);

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaxLayersInWhinBox).HasColumnName("MaxLayersInWHinBox");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PalletPn)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PalletPN");
            entity.Property(e => e.PalletStackWhinPallet).HasColumnName("PalletStackWHinPallet");
            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tstamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Recipient>(entity =>
        {
            entity.HasKey(e => e.RecipientId).HasName("PK__Recipients__75A278F5");

            entity.Property(e => e.Adress1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Adress2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Contact)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fax3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Flow)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name2)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nip)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NIP");
            entity.Property(e => e.Phone1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Recipient1).HasColumnName("Recipient");
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false);
            entity.Property(e => e.Sapid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SAPId");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Www)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WWW");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
