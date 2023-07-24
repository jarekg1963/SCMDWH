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

    public virtual DbSet<FgGit> FgGits { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPallet> ProductPallets { get; set; }

    public virtual DbSet<Recipient> Recipients { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentsItem> ShipmentsItems { get; set; }

    public virtual DbSet<ShipmentsPallet> ShipmentsPallets { get; set; }

    public virtual DbSet<ShipmentsPlan> ShipmentsPlans { get; set; }

    public virtual DbSet<VmciPoItem> VmciPoItems { get; set; }

    public virtual DbSet<VmciPoList> VmciPoLists { get; set; }

    public virtual DbSet<VmciPoPosting> VmciPoPostings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.CarrierId).HasName("PK__Carriers__7C8480AE");

            entity.Property(e => e.Active)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')")
                .IsFixedLength();
            entity.Property(e => e.Adress1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Adress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Contact1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Contact2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Contact3)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Email1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Email3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Fax1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Fax2)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Fax3)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Nip)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("NIP");
            entity.Property(e => e.PartyType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Phone1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Phone2)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Phone3)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ShortName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.VendorCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Www)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("WWW");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
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
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CarriageInstruction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CmrcarrierId1).HasColumnName("CMRCarrierID1");
            entity.Property(e => e.CmrcarrierId2).HasColumnName("CMRCarrierID2");
            entity.Property(e => e.Cmrdate)
                .HasColumnType("datetime")
                .HasColumnName("CMRdate");
            entity.Property(e => e.Cmrnumber).HasColumnName("CMRNumber");
            entity.Property(e => e.Consigment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ConsigneeId).HasColumnName("ConsigneeID");
            entity.Property(e => e.ContainerNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('EUR')")
                .IsFixedLength();
            entity.Property(e => e.DeliveryPlaceId).HasColumnName("DeliveryPlaceID");
            entity.Property(e => e.Driver)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.EShpReadyToReport).HasColumnName("E_Shp_ReadyToReport");
            entity.Property(e => e.EstablishedDate).HasColumnType("datetime");
            entity.Property(e => e.EstablishedPlace)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.LastReportResultMessage)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.LastReportTime).HasColumnType("datetime");
            entity.Property(e => e.LoadingDate).HasColumnType("datetime");
            entity.Property(e => e.LoadingPlaceId).HasColumnName("LoadingPlaceID");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PrintTime).HasColumnType("datetime");
            entity.Property(e => e.PrintUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.RegistrationsNo)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Seal1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Seal2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SenderInstruction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')")
                .IsFixedLength();
            entity.Property(e => e.TruckServiceBscode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("TruckServiceBSCODE");
            entity.Property(e => e.TruckServiceName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.TruckType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
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
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.NatureOfGoods)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Packing)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Quantity).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.StatisticalNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Volume).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.Weight).HasColumnType("decimal(15, 3)");
            entity.Property(e => e.WeightUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
        });

        modelBuilder.Entity<DailyProductionPlanExcel>(entity =>
        {
            entity.HasKey(e => e.WorkOrderNo);

            entity.ToTable("DailyProductionPlanExcel");

            entity.Property(e => e.WorkOrderNo).HasMaxLength(100);
            entity.Property(e => e.Ctn)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Customer)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CycleTime)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.EndD)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.EndH)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.InsertTime).HasColumnType("datetime");
            entity.Property(e => e.Invoice)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.LhgStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Not confirmed')")
                .HasColumnName("LHG_Status");
            entity.Property(e => e.LineName)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.MinCt)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("MinCT");
            entity.Property(e => e.OryginalCtnFromFile)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Pcsh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PCSH");
            entity.Property(e => e.SlImportedToWms).HasColumnName("SL_ImportedToWMS");
            entity.Property(e => e.SlStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('Not Started')")
                .HasColumnName("SL_Status");
            entity.Property(e => e.SsbPn).IsUnicode(false);
            entity.Property(e => e.StartD)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.StartH)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Team)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.TpvModel)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.TunerAssy)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.TunerWo)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.WoActivityStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.WoEndTime).HasColumnType("datetime");
            entity.Property(e => e.WoNumberValidated)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.WoStartTime).HasColumnType("datetime");
            entity.Property(e => e.WorkOrderStatus).HasDefaultValueSql("('')");
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

        modelBuilder.Entity<FgGit>(entity =>
        {
            entity.ToTable("FG_GIT");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustomerOrderNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Dddestination)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DDdestination");
            entity.Property(e => e.Fgzone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FGzone");
            entity.Property(e => e.LeaveLocation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LeaveTimie).HasColumnType("datetime");
            entity.Property(e => e.PalletNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PickUpFromLocation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ProductQuantity).HasDefaultValueSql("((0))");
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TargetWhType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.XlSize).HasColumnName("XL_Size");
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
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Depth).HasColumnType("decimal(16, 3)");
            entity.Property(e => e.Height).HasColumnType("decimal(16, 3)");
            entity.Property(e => e.MatWeight).HasColumnType("decimal(16, 5)");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Mrpcontroller)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("MRPController");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.TpvisionWeight)
                .HasColumnType("decimal(16, 5)")
                .HasColumnName("TPVisionWeight");
            entity.Property(e => e.TpvisionWeightUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("TPVisionWeightUnit");
            entity.Property(e => e.UnitOfDimension)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.WeightUnit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
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
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.MaxLayersInWhinBox).HasColumnName("MaxLayersInWHinBox");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PalletPn)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PalletPN");
            entity.Property(e => e.PalletStackWhinPallet).HasColumnName("PalletStackWHinPallet");
            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
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
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Adress2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Contact)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Email1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Email3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Fax1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Fax2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Fax3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Flow)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Name2)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Nip)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("NIP");
            entity.Property(e => e.Phone1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Phone2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Phone3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Recipient1)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("Recipient");
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Sapid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SAPId");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Www)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("WWW");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentId).HasName("PK__Shipments__10566F31");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("Shipments_TrigIns");
                    tb.HasTrigger("Shipments_TrigUpd");
                });

            entity.HasIndex(e => e.ShipmentDate, "Shipments_IND1").HasFillFactor(85);

            entity.HasIndex(e => e.CmrdocId, "Shipments_IND2").HasFillFactor(85);

            entity.HasIndex(e => e.ShipmentNo, "Shipments_IND4")
                .IsUnique()
                .HasFillFactor(85);

            entity.HasIndex(e => e.Cmrnumber, "Turbo_Index__01__2017_09_01").HasFillFactor(85);

            entity.Property(e => e.AttachedDocs)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CarriageInstruction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CmrattachDate)
                .HasColumnType("datetime")
                .HasColumnName("CMRAttachDate");
            entity.Property(e => e.CmrcarrierId1).HasColumnName("CMRCarrierID1");
            entity.Property(e => e.CmrcarrierId2).HasColumnName("CMRCarrierID2");
            entity.Property(e => e.CmrdocId).HasColumnName("CMRdocId");
            entity.Property(e => e.Cmrnumber).HasColumnName("CMRNumber");
            entity.Property(e => e.CompleteDate).HasColumnType("datetime");
            entity.Property(e => e.Confirmed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ConsigneeId).HasColumnName("ConsigneeID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerOrderNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Dddestination)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("DDdestination");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveryNote)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.DeliveryPlaceId).HasColumnName("DeliveryPlaceID");
            entity.Property(e => e.EshipStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('Released')");
            entity.Property(e => e.EstablishedDate).HasColumnType("datetime");
            entity.Property(e => e.EstablishedPlace)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.LeaveDate).HasColumnType("datetime");
            entity.Property(e => e.LoadingDate).HasColumnType("datetime");
            entity.Property(e => e.LoadingPlaceId).HasColumnName("LoadingPlaceID");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PtsErrorMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PtsMessageId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsMessageID");
            entity.Property(e => e.PtsReportedTime).HasColumnType("datetime");
            entity.Property(e => e.PtsTransId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsTransID");
            entity.Property(e => e.RegistrationsNo)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Sapid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SAPId");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");
            entity.Property(e => e.SenderInstruction)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ShipmentDate).HasColumnType("datetime");
            entity.Property(e => e.ShipmentNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.SntoSfisresult)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SNtoSFISresult");
            entity.Property(e => e.SntoSfistime)
                .HasColumnType("datetime")
                .HasColumnName("SNtoSFIStime");
            entity.Property(e => e.SoldTo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')")
                .IsFixedLength();
            entity.Property(e => e.StatusBefore)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.StatusChangedTime).HasColumnType("datetime");
            entity.Property(e => e.SubBg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("SUB_BG");
            entity.Property(e => e.TruckCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<ShipmentsItem>(entity =>
        {
            entity.HasKey(e => e.ShipmentItemId).HasName("PK__ShipmentsItems__1BC821DD");

            entity.HasIndex(e => e.ShipmentPalletId, "ShipmentsItems_ind1").HasFillFactor(85);

            entity.HasIndex(e => e.ProductCode, "ShipmentsItems_ind2").HasFillFactor(85);

            entity.HasIndex(e => e.SerialNo, "ShipmentsItems_ind3").HasFillFactor(85);

            entity.HasIndex(e => e.WorkOrder, "ShipmentsItems_ind4").HasFillFactor(85);

            entity.HasIndex(e => e.BoxNo, "ShipmentsItems_ind5").HasFillFactor(85);

            entity.HasIndex(e => e.CustomerOrderNo, "ShipmentsItems_ind6").HasFillFactor(85);

            entity.HasIndex(e => e.CreateDate, "Turbo_Index__01__2014_05_07").HasFillFactor(85);

            entity.HasIndex(e => e.CreateDate, "Turbo_Index__02__2017_08_21").HasFillFactor(85);

            entity.HasIndex(e => e.ShipmentPalletId, "Turbo_Index__03__2017_09_01").HasFillFactor(85);

            entity.HasIndex(e => e.CreateDate, "Turbo_Index__04__2018_04_24").HasFillFactor(85);

            entity.HasIndex(e => e.ShipmentPalletId, "Turbo_Index__05__2018_11_07").HasFillFactor(85);

            entity.HasIndex(e => e.CustomerNo, "Turbo_Index__06__2019_02_04").HasFillFactor(85);

            entity.HasIndex(e => e.CustomerNo, "Turbo_Index__07__2023_06_21").HasFillFactor(85);

            entity.HasIndex(e => new { e.CustomerNo, e.CreateDate }, "Turbo_Index__08__2023_06_21").HasFillFactor(85);

            entity.HasIndex(e => e.ShipmentPalletId, "Turbo_Index__09__2023_07_05").HasFillFactor(85);

            entity.Property(e => e.BoxNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerOrderNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Dddestination)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("DDdestination");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PanelSerialNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PtsErrorMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PtsMessageId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsMessageID");
            entity.Property(e => e.PtsReportedTime).HasColumnType("datetime");
            entity.Property(e => e.PtsTransId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsTransID");
            entity.Property(e => e.RepackPalletNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.RepackProdLine)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.RepackTime).HasColumnType("datetime");
            entity.Property(e => e.SerialNo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Swver)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SWver");
            entity.Property(e => e.Swversion).HasColumnName("SWversion");
            entity.Property(e => e.WorkOrder)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
        });

        modelBuilder.Entity<ShipmentsPallet>(entity =>
        {
            entity.HasKey(e => e.ShipmentPalletId).HasName("PK__ShipmentsPallets__245D67DE");

            entity.HasIndex(e => e.ShipmentId, "ShipmentsPallets_IND1").HasFillFactor(85);

            entity.HasIndex(e => e.PalletDate, "ShipmentsPallets_IND2").HasFillFactor(85);

            entity.HasIndex(e => e.PalletNo, "ShipmentsPallets_IND3")
                .IsUnique()
                .HasFillFactor(85);

            entity.HasIndex(e => e.Dddestination, "ShipmentsPallets_ind4").HasFillFactor(85);

            entity.HasIndex(e => e.SkdpartNo, "ShipmentsPallets_ind5").HasFillFactor(85);

            entity.HasIndex(e => e.FglocId, "Turbo_Index__01__2014_05_07").HasFillFactor(85);

            entity.HasIndex(e => new { e.ShipmentId, e.ProductCode, e.Status, e.Fglocation }, "Turbo_Index__02__2014_05_07").HasFillFactor(85);

            entity.HasIndex(e => e.Fglocation, "Turbo_Index__03__2014_05_07").HasFillFactor(85);

            entity.HasIndex(e => new { e.ProductionLine, e.PalletNo }, "Turbo_Index__04__2014_05_07").HasFillFactor(85);

            entity.HasIndex(e => new { e.Status, e.FglocId }, "Turbo_Index__05__2014_05_07").HasFillFactor(85);

            entity.HasIndex(e => new { e.ShipmentId, e.Status, e.QcontrolStatus, e.Fglocation, e.Dddestination }, "Turbo_Index__06__2018_10_10").HasFillFactor(85);

            entity.HasIndex(e => new { e.ShipmentId, e.Status, e.QcontrolStatus, e.Fgzone }, "Turbo_Index__07__2018_11_07").HasFillFactor(85);

            entity.HasIndex(e => new { e.Status, e.Fgzone }, "Turbo_Index__08__2023_03_09").HasFillFactor(85);

            entity.HasIndex(e => new { e.Status, e.FglocId, e.Fgzone }, "Turbo_Index__09__2023_03_09").HasFillFactor(85);

            entity.HasIndex(e => new { e.Status, e.Fglocation, e.Dddestination, e.QcontrolStatus }, "Turbo_Index__10__2023_06_07").HasFillFactor(85);

            entity.HasIndex(e => new { e.CustomerOrderNo, e.Status, e.Fgzone }, "Turbo_Index__11__2023_07_05").HasFillFactor(85);

            entity.Property(e => e.BrwkEntryId).HasColumnName("BRWK_ENTRY_ID");
            entity.Property(e => e.ConfirmStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ConfirmingUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerOrderNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerPalletNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Dddestination)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("DDdestination");
            entity.Property(e => e.FglocId).HasColumnName("FGlocId");
            entity.Property(e => e.Fglocation)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("FGlocation");
            entity.Property(e => e.FglocationWh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("FGlocationWH");
            entity.Property(e => e.Fgsltime)
                .HasColumnType("datetime")
                .HasColumnName("FGSLtime");
            entity.Property(e => e.Fgzone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("FGzone");
            entity.Property(e => e.FgzoneWh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("FGzoneWH");
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PalletDate).HasColumnType("datetime");
            entity.Property(e => e.PalletNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PalletPn)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PalletPN");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ProductionLine)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PtsErrorMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PtsMessageId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsMessageID");
            entity.Property(e => e.PtsReportedTime).HasColumnType("datetime");
            entity.Property(e => e.PtsTransId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsTransID");
            entity.Property(e => e.QcontrolStatus)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("QControlStatus");
            entity.Property(e => e.QcstatusDate)
                .HasColumnType("datetime")
                .HasColumnName("QCStatusDate");
            entity.Property(e => e.Remarks)
                .HasMaxLength(800)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')")
                .IsFixedLength();
            entity.Property(e => e.Swver)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SWver");
            entity.Property(e => e.Swversion).HasColumnName("SWversion");
        });

        modelBuilder.Entity<ShipmentsPlan>(entity =>
        {
            entity.HasKey(e => e.ShipmentPlanId).HasName("PK__ShipmentsPlan__0CDAE408");

            entity.ToTable("ShipmentsPlan");

            entity.HasIndex(e => e.ShipmentId, "ShipmentsPlan_ind1").HasFillFactor(85);

            entity.HasIndex(e => new { e.DeliveryNote, e.DeliveryItem }, "Turbo_Index__01__2015_11_16").HasFillFactor(85);

            entity.Property(e => e.BaseUnit)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ConfirmTime).HasColumnType("datetime");
            entity.Property(e => e.Confirmed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.CustomerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.DeliveryItem)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.DeliveryNote)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.FileSeqNo)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ModifyUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.PostingTime).HasColumnType("datetime");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ProgramDate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ProgramTime)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.ResultMessage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.SkdpartNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength()
                .HasColumnName("SKDPartNo");
            entity.Property(e => e.Sloc)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
            entity.Property(e => e.Stamp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .IsFixedLength();
        });

        modelBuilder.Entity<VmciPoItem>(entity =>
        {
            entity.HasKey(e => e.PoitemId);

            entity.ToTable("VMCI_PO_Items");

            entity.Property(e => e.PoitemId).HasColumnName("POItemId");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("smalldatetime");
            entity.Property(e => e.LastUpdateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.OrderNo)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ProductNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ProductTpvNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.HasOne(d => d.OrderNoNavigation).WithMany(p => p.VmciPoItems)
                .HasForeignKey(d => d.OrderNo)
                .HasConstraintName("FK_VMCI_PO_Items_VMCI_PO_List");
        });

        modelBuilder.Entity<VmciPoList>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.ToTable("VMCI_PO_List");

            entity.Property(e => e.OrderNo)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreateUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.ImportTime).HasColumnType("smalldatetime");
            entity.Property(e => e.ItemNo).HasDefaultValueSql("((10))");
            entity.Property(e => e.OrderType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Purchase Order')");
            entity.Property(e => e.PlanDelivDate).HasColumnType("smalldatetime");
            entity.Property(e => e.ProductNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('P')")
                .IsFixedLength();
        });

        modelBuilder.Entity<VmciPoPosting>(entity =>
        {
            entity.HasKey(e => e.PopostingId);

            entity.ToTable("VMCI_PO_Postings");

            entity.HasIndex(e => new { e.PoitemId, e.PalletNo }, "No_Duplicate_Scan")
                .IsUnique()
                .HasFillFactor(85);

            entity.HasIndex(e => new { e.PoitemId, e.RetrySapPost, e.Lock }, "Turbo_Index__01__2015_04_14").HasFillFactor(85);

            entity.HasIndex(e => new { e.ReadyForCevaSend, e.Lock, e.Status }, "Turbo_Index__02__2015_04_14").HasFillFactor(85);

            entity.HasIndex(e => new { e.ReadyForSapPost, e.Lock }, "Turbo_Index__03__2015_04_14").HasFillFactor(85);

            entity.HasIndex(e => e.CevaConfirmedRework, "Turbo_Index__04__2015_04_14").HasFillFactor(85);

            entity.HasIndex(e => e.PostingKey, "Turbo_Index__05__2017_09_01").HasFillFactor(85);

            entity.HasIndex(e => e.ProductTpvNo, "Turbo_Index__06__2023_01_03").HasFillFactor(85);

            entity.HasIndex(e => e.AsnTime, "Turbo_Index__07__2023_01_03").HasFillFactor(85);

            entity.Property(e => e.PopostingId).HasColumnName("POPostingId");
            entity.Property(e => e.AsnTime).HasColumnType("smalldatetime");
            entity.Property(e => e.ConfirmedTime).HasColumnType("smalldatetime");
            entity.Property(e => e.CreateUserId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreatedTime).HasColumnType("smalldatetime");
            entity.Property(e => e.FileSeqNo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PalletNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PoitemId).HasColumnName("POItemId");
            entity.Property(e => e.PostedTime).HasColumnType("smalldatetime");
            entity.Property(e => e.ProductTpvNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PtsErrorMessage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.PtsMessageId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsMessageID");
            entity.Property(e => e.PtsReportedTime).HasColumnType("datetime");
            entity.Property(e => e.PtsTransId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("PtsTransID");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('N')")
                .IsFixedLength();
            entity.Property(e => e.Xi429fileName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("XI429FileName");

            entity.HasOne(d => d.Poitem).WithMany(p => p.VmciPoPostings)
                .HasForeignKey(d => d.PoitemId)
                .HasConstraintName("FK_VMCI_PO_Postings_VMCI_PO_Items");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
