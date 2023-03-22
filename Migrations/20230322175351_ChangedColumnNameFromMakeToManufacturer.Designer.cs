﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCBuilder;

#nullable disable

namespace PCBuilder.Migrations
{
    [DbContext(typeof(PCBuilderDbContext))]
    [Migration("20230322175351_ChangedColumnNameFromMakeToManufacturer")]
    partial class ChangedColumnNameFromMakeToManufacturer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CPUCPUCooler", b =>
                {
                    b.Property<int>("CompatibleCpuCoolersId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleCpusId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCpuCoolersId", "CompatibleCpusId");

                    b.HasIndex("CompatibleCpusId");

                    b.ToTable("CPUCPUCooler");
                });

            modelBuilder.Entity("CPUCoolerSocket", b =>
                {
                    b.Property<int>("CPUCoolersId")
                        .HasColumnType("int");

                    b.Property<int>("SocketsId")
                        .HasColumnType("int");

                    b.HasKey("CPUCoolersId", "SocketsId");

                    b.HasIndex("SocketsId");

                    b.ToTable("CPUCoolerSocket");
                });

            modelBuilder.Entity("CPUMotherboard", b =>
                {
                    b.Property<int>("CompatibleCpusId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleMotherboardsId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCpusId", "CompatibleMotherboardsId");

                    b.HasIndex("CompatibleMotherboardsId");

                    b.ToTable("CPUMotherboard");
                });

            modelBuilder.Entity("CaseGPU", b =>
                {
                    b.Property<int>("CompatibleCasesId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleGpusId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCasesId", "CompatibleGpusId");

                    b.HasIndex("CompatibleGpusId");

                    b.ToTable("CaseGPU");
                });

            modelBuilder.Entity("CaseMotherboard", b =>
                {
                    b.Property<int>("CompatibleCasesId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleMotherboardsId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCasesId", "CompatibleMotherboardsId");

                    b.HasIndex("CompatibleMotherboardsId");

                    b.ToTable("CaseMotherboard");
                });

            modelBuilder.Entity("CasePowerSupply", b =>
                {
                    b.Property<int>("CompatibleCasesId")
                        .HasColumnType("int");

                    b.Property<int>("CompatiblePowerSuppliesId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCasesId", "CompatiblePowerSuppliesId");

                    b.HasIndex("CompatiblePowerSuppliesId");

                    b.ToTable("CasePowerSupply");
                });

            modelBuilder.Entity("CaseStorage", b =>
                {
                    b.Property<int>("CompatibleCasesId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleStoragesId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCasesId", "CompatibleStoragesId");

                    b.HasIndex("CompatibleStoragesId");

                    b.ToTable("CaseStorage");
                });

            modelBuilder.Entity("InternalConnectorMotherboard", b =>
                {
                    b.Property<int>("InternalConnectorsId")
                        .HasColumnType("int");

                    b.Property<int>("MotherboardsId")
                        .HasColumnType("int");

                    b.HasKey("InternalConnectorsId", "MotherboardsId");

                    b.HasIndex("MotherboardsId");

                    b.ToTable("InternalConnectorMotherboard");
                });

            modelBuilder.Entity("InternalConnectorPowerSupply", b =>
                {
                    b.Property<int>("ConnectorsId")
                        .HasColumnType("int");

                    b.Property<int>("PowerSuppliesId")
                        .HasColumnType("int");

                    b.HasKey("ConnectorsId", "PowerSuppliesId");

                    b.HasIndex("PowerSuppliesId");

                    b.ToTable("InternalConnectorPowerSupply");
                });

            modelBuilder.Entity("MotherboardPort", b =>
                {
                    b.Property<int>("BackPanelPortsId")
                        .HasColumnType("int");

                    b.Property<int>("MotherboardsId")
                        .HasColumnType("int");

                    b.HasKey("BackPanelPortsId", "MotherboardsId");

                    b.HasIndex("MotherboardsId");

                    b.ToTable("MotherboardPort");
                });

            modelBuilder.Entity("MotherboardRAM", b =>
                {
                    b.Property<int>("CompatibleMotherboardsId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleRamId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleMotherboardsId", "CompatibleRamId");

                    b.HasIndex("CompatibleRamId");

                    b.ToTable("MotherboardRAM");
                });

            modelBuilder.Entity("MotherboardStorageSlot", b =>
                {
                    b.Property<int>("MotherboardsId")
                        .HasColumnType("int");

                    b.Property<int>("StorageSlotsId")
                        .HasColumnType("int");

                    b.HasKey("MotherboardsId", "StorageSlotsId");

                    b.HasIndex("StorageSlotsId");

                    b.ToTable("MotherboardStorageSlot");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BaseClock")
                        .HasColumnType("float");

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxBoostClock")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RAMId")
                        .HasColumnType("int");

                    b.Property<int>("SocketId")
                        .HasColumnType("int");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RAMId");

                    b.HasIndex("SocketId");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.CPUCooler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxRPM")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoiseLevel")
                        .HasColumnType("int");

                    b.Property<int>("TDP")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CPUCoolers");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Case", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherboardFormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Chipset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chipsets");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BaseClock")
                        .HasColumnType("float");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxBoostClock")
                        .HasColumnType("float");

                    b.Property<int>("MemoryBus")
                        .HasColumnType("int");

                    b.Property<int>("MemorySize")
                        .HasColumnType("int");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TDP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GPUs");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.InternalConnector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InternalConnectors");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChipsetId")
                        .HasColumnType("int");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxMemorySpeed")
                        .HasColumnType("int");

                    b.Property<int>("MemorySlots")
                        .HasColumnType("int");

                    b.Property<string>("MemoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SocketId")
                        .HasColumnType("int");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ChipsetId");

                    b.HasIndex("SocketId");

                    b.ToTable("MotherBoards");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Port", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ports");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EfficiencyRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wattage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PowerSupplies");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Memories");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Socket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sockets");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interface")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReadSpeed")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WriteSpeed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.StorageSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StorageSlots");
                });

            modelBuilder.Entity("CPUCPUCooler", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.CPUCooler", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCpuCoolersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.CPU", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPUCoolerSocket", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.CPUCooler", null)
                        .WithMany()
                        .HasForeignKey("CPUCoolersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Socket", null)
                        .WithMany()
                        .HasForeignKey("SocketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CPUMotherboard", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.CPU", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("CompatibleMotherboardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseGPU", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Case", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.GPU", null)
                        .WithMany()
                        .HasForeignKey("CompatibleGpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseMotherboard", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Case", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("CompatibleMotherboardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CasePowerSupply", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Case", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.PowerSupply", null)
                        .WithMany()
                        .HasForeignKey("CompatiblePowerSuppliesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CaseStorage", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Case", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Storage", null)
                        .WithMany()
                        .HasForeignKey("CompatibleStoragesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternalConnectorMotherboard", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.InternalConnector", null)
                        .WithMany()
                        .HasForeignKey("InternalConnectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("MotherboardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InternalConnectorPowerSupply", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.InternalConnector", null)
                        .WithMany()
                        .HasForeignKey("ConnectorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.PowerSupply", null)
                        .WithMany()
                        .HasForeignKey("PowerSuppliesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MotherboardPort", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Port", null)
                        .WithMany()
                        .HasForeignKey("BackPanelPortsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("MotherboardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MotherboardRAM", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("CompatibleMotherboardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.RAM", null)
                        .WithMany()
                        .HasForeignKey("CompatibleRamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MotherboardStorageSlot", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("MotherboardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.StorageSlot", null)
                        .WithMany()
                        .HasForeignKey("StorageSlotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCBuilder.Models.DB.CPU", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.RAM", null)
                        .WithMany("CompatibleCpus")
                        .HasForeignKey("RAMId");

                    b.HasOne("PCBuilder.Models.DB.Socket", "Socket")
                        .WithMany()
                        .HasForeignKey("SocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Socket");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Motherboard", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Chipset", "Chipset")
                        .WithMany()
                        .HasForeignKey("ChipsetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Socket", "Socket")
                        .WithMany()
                        .HasForeignKey("SocketId");

                    b.Navigation("Chipset");

                    b.Navigation("Socket");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.RAM", b =>
                {
                    b.Navigation("CompatibleCpus");
                });
#pragma warning restore 612, 618
        }
    }
}
