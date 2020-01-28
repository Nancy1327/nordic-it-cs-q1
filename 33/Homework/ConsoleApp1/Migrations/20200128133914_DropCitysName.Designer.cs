﻿// <auto-generated />
using System;
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp1.Migrations
{
    [DbContext(typeof(OnlineStoreContext))]
    [Migration("20200128133914_DropCitysName")]
    partial class DropCitysName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp1.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int?>("CityNameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityNameId");

                    b.ToTable("Addresss");
                });

            modelBuilder.Entity("ConsoleApp1.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Citys");
                });

            modelBuilder.Entity("ConsoleApp1.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressNameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<int?>("PositionNameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressNameId");

                    b.HasIndex("PositionNameId");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("ConsoleApp1.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ConsoleApp1.DocumentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("DocumentStatuss");
                });

            modelBuilder.Entity("ConsoleApp1.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ConsoleApp1.Address", b =>
                {
                    b.HasOne("ConsoleApp1.City", "CityName")
                        .WithMany("Addresss")
                        .HasForeignKey("CityNameId");
                });

            modelBuilder.Entity("ConsoleApp1.Contractor", b =>
                {
                    b.HasOne("ConsoleApp1.Address", "AddressName")
                        .WithMany("Contractors")
                        .HasForeignKey("AddressNameId");

                    b.HasOne("ConsoleApp1.Position", "PositionName")
                        .WithMany("Contractors")
                        .HasForeignKey("PositionNameId");
                });

            modelBuilder.Entity("ConsoleApp1.DocumentStatus", b =>
                {
                    b.HasOne("ConsoleApp1.Document", "Document")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentId");

                    b.HasOne("ConsoleApp1.Contractor", "Receiver")
                        .WithMany("DocumentsReceiver")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("ConsoleApp1.Contractor", "Sender")
                        .WithMany("DocumentsSender")
                        .HasForeignKey("SenderId");
                });
#pragma warning restore 612, 618
        }
    }
}
