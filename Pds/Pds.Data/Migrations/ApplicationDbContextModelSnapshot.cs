﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pds.Data;

namespace Pds.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("BrandPerson", b =>
                {
                    b.Property<Guid>("BrandsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BrandsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("BrandPerson");
                });

            modelBuilder.Entity("Pds.Data.Entities.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(300)");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PaidAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContentId")
                        .IsUnique()
                        .HasFilter("[ContentId] IS NOT NULL");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Pds.Data.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5aa23fa2-4b73-4a3f-c3d4-08d8d2705c5f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "АйТиБорода",
                            Url = "https://youtube.com/itbeard"
                        },
                        new
                        {
                            Id = new Guid("6bb23fa2-4b73-4a3f-c3d4-08d8d2705c5f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Тёмный Лес",
                            Url = "https://youtube.com/thedarkless"
                        });
                });

            modelBuilder.Entity("Pds.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Pds.Data.Entities.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("SocialMediaType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("PersonId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("Pds.Data.Entities.Cost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ContentId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("Pds.Data.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ArchivedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("ThirdName")
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime?>("UnarchivedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Pds.Data.Entities.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("BrandPerson", b =>
                {
                    b.HasOne("Pds.Data.Entities.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pds.Data.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pds.Data.Entities.Bill", b =>
                {
                    b.HasOne("Pds.Data.Entities.Brand", "Brand")
                        .WithMany("Bills")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pds.Data.Entities.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("ClientId");

                    b.HasOne("Pds.Data.Entities.Content", "Content")
                        .WithOne("Bill")
                        .HasForeignKey("Pds.Data.Entities.Bill", "ContentId");

                    b.Navigation("Brand");

                    b.Navigation("Client");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Pds.Data.Entities.Content", b =>
                {
                    b.HasOne("Pds.Data.Entities.Brand", "Brand")
                        .WithMany("Contents")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pds.Data.Entities.Person", "Person")
                        .WithMany("Contents")
                        .HasForeignKey("PersonId");

                    b.Navigation("Brand");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Pds.Data.Entities.Cost", b =>
                {
                    b.HasOne("Pds.Data.Entities.Brand", "Brand")
                        .WithMany("Costs")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pds.Data.Entities.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.Navigation("Brand");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Pds.Data.Entities.Resource", b =>
                {
                    b.HasOne("Pds.Data.Entities.Person", "Person")
                        .WithMany("Resources")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Pds.Data.Entities.Brand", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Contents");

                    b.Navigation("Costs");
                });

            modelBuilder.Entity("Pds.Data.Entities.Client", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("Pds.Data.Entities.Content", b =>
                {
                    b.Navigation("Bill");
                });

            modelBuilder.Entity("Pds.Data.Entities.Person", b =>
                {
                    b.Navigation("Contents");

                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
