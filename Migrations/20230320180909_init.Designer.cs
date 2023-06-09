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
    [Migration("20230320180909_init")]
    partial class init
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

            modelBuilder.Entity("CPURAM", b =>
                {
                    b.Property<int>("CompatibleCpusId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleRamId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleCpusId", "CompatibleRamId");

                    b.HasIndex("CompatibleRamId");

                    b.ToTable("CPURAM");
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

            modelBuilder.Entity("GPUMotherboard", b =>
                {
                    b.Property<int>("CompatibleGpusId")
                        .HasColumnType("int");

                    b.Property<int>("CompatibleMotherboardsId")
                        .HasColumnType("int");

                    b.HasKey("CompatibleGpusId", "CompatibleMotherboardsId");

                    b.HasIndex("CompatibleMotherboardsId");

                    b.ToTable("GPUMotherboard");
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

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxBoostClock")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Threads")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.CPUCooler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Make")
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

                    b.Property<int?>("GPUId")
                        .HasColumnType("int");

                    b.Property<string>("Manufactorer")
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

                    b.HasIndex("GPUId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.GPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BaseClock")
                        .HasColumnType("float");

                    b.Property<string>("Make")
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

            modelBuilder.Entity("PCBuilder.Models.DB.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Chipset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Make")
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

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MotherBoards");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Port", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MotherboardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PowerSupplyId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("PowerSupplyId");

                    b.ToTable("Port");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.PowerSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaseId")
                        .HasColumnType("int");

                    b.Property<string>("EfficiencyRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GPUId")
                        .HasColumnType("int");

                    b.Property<string>("Manufactorer")
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

                    b.HasIndex("CaseId");

                    b.HasIndex("GPUId");

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

                    b.Property<string>("Make")
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

                    b.Property<int?>("CPUCoolerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CPUCoolerId");

                    b.ToTable("Sockets");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.StorageSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaseId")
                        .HasColumnType("int");

                    b.Property<int?>("MotherboardId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.HasIndex("MotherboardId");

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

            modelBuilder.Entity("CPURAM", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.CPU", null)
                        .WithMany()
                        .HasForeignKey("CompatibleCpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.RAM", null)
                        .WithMany()
                        .HasForeignKey("CompatibleRamId")
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

            modelBuilder.Entity("GPUMotherboard", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.GPU", null)
                        .WithMany()
                        .HasForeignKey("CompatibleGpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany()
                        .HasForeignKey("CompatibleMotherboardsId")
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

            modelBuilder.Entity("PCBuilder.Models.DB.Case", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.GPU", null)
                        .WithMany("CompatibleCases")
                        .HasForeignKey("GPUId");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Port", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany("Ports")
                        .HasForeignKey("MotherboardId");

                    b.HasOne("PCBuilder.Models.DB.PowerSupply", null)
                        .WithMany("Connectors")
                        .HasForeignKey("PowerSupplyId");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.PowerSupply", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Case", null)
                        .WithMany("CompatiblePowerSupplies")
                        .HasForeignKey("CaseId");

                    b.HasOne("PCBuilder.Models.DB.GPU", null)
                        .WithMany("CompatiblePowerSupplies")
                        .HasForeignKey("GPUId");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Socket", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.CPUCooler", null)
                        .WithMany("Sockets")
                        .HasForeignKey("CPUCoolerId");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.StorageSlot", b =>
                {
                    b.HasOne("PCBuilder.Models.DB.Case", null)
                        .WithMany("CompatibleStorageSlots")
                        .HasForeignKey("CaseId");

                    b.HasOne("PCBuilder.Models.DB.Motherboard", null)
                        .WithMany("StorageSlots")
                        .HasForeignKey("MotherboardId");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.CPUCooler", b =>
                {
                    b.Navigation("Sockets");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Case", b =>
                {
                    b.Navigation("CompatiblePowerSupplies");

                    b.Navigation("CompatibleStorageSlots");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.GPU", b =>
                {
                    b.Navigation("CompatibleCases");

                    b.Navigation("CompatiblePowerSupplies");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.Motherboard", b =>
                {
                    b.Navigation("Ports");

                    b.Navigation("StorageSlots");
                });

            modelBuilder.Entity("PCBuilder.Models.DB.PowerSupply", b =>
                {
                    b.Navigation("Connectors");
                });
#pragma warning restore 612, 618
        }
    }
}
