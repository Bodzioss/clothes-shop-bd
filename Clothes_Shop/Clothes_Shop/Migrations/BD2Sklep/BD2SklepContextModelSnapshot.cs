﻿// <auto-generated />
using System;
using Clothes_Shop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clothes_Shop.Migrations.BD2Sklep
{
    [DbContext(typeof(BD2SklepContext))]
    partial class BD2SklepContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clothes_Shop.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnName("CityID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("HomeNumber")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetId")
                        .HasColumnName("StreetID")
                        .HasColumnType("int");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.HasIndex("StreetId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Clothes_Shop.Models.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BasketID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BasketId");

                    b.HasIndex("UserId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("Clothes_Shop.Models.BasketDetails", b =>
                {
                    b.Property<int>("BasketDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BasketDetailsID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasketId")
                        .HasColumnName("BasketID")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketDetailsId");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketDetails");
                });

            modelBuilder.Entity("Clothes_Shop.Models.BrandTab", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BrandID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("BrandId");

                    b.HasIndex("BrandName")
                        .HasName("IX_BrandTab");

                    b.ToTable("BrandTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.CategoryTab", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("varchar(2048)")
                        .HasMaxLength(2048)
                        .IsUnicode(false);

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryName")
                        .HasName("IX_CategoryTab");

                    b.ToTable("CategoryTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.CityTab", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CityID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CityId");

                    b.HasIndex("CityName")
                        .HasName("IX_CityTab");

                    b.ToTable("CityTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.ClientAddress", b =>
                {
                    b.Property<int>("ClientAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClientAddressID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnName("CityID")
                        .HasColumnType("int");

                    b.Property<string>("HomeNumber")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<bool>("IsMain")
                        .HasColumnName("isMain")
                        .HasColumnType("bit");

                    b.Property<int>("StreetId")
                        .HasColumnName("StreetID")
                        .HasColumnType("int");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.HasKey("ClientAddressId");

                    b.HasIndex("CityId");

                    b.HasIndex("StreetId");

                    b.HasIndex("UserId");

                    b.ToTable("ClientAddress");
                });

            modelBuilder.Entity("Clothes_Shop.Models.ColorTab", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ColorID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("ColorId")
                        .HasName("PK_ColorName");

                    b.HasIndex("ColorName")
                        .HasName("IX_ColorTab");

                    b.ToTable("ColorTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.GenderTab", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GenderID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("GenderId");

                    b.HasIndex("GenderName")
                        .HasName("IX_GenderTab");

                    b.ToTable("GenderTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.MaterialTab", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MaterialID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("MaterialId");

                    b.HasIndex("MaterialName")
                        .HasName("IX_MaterialTab");

                    b.ToTable("MaterialTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.Opinion", b =>
                {
                    b.Property<int>("OpinionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OpinionID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<byte>("Rate")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OpinionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Opinion");
                });

            modelBuilder.Entity("Clothes_Shop.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderDetailsID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Clothes_Shop.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrderID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("date");

                    b.Property<int>("ShipperId")
                        .HasColumnName("ShipperID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId")
                        .HasName("PK_Order");

                    b.HasIndex("OrderDate")
                        .HasName("IX_Orders_1");

                    b.HasIndex("ShipperId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Clothes_Shop.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnName("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnName("ColorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnName("GenderID")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnName("MaterialID")
                        .HasColumnType("int");

                    b.Property<string>("Pattern")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Season")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SizeId")
                        .HasColumnName("SizeID")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("Amount")
                        .HasName("IX_Product_5");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("Pattern")
                        .HasName("IX_Product_4");

                    b.HasIndex("Price")
                        .HasName("IX_Product_1");

                    b.HasIndex("ProductName")
                        .HasName("IX_Product_2");

                    b.HasIndex("Season")
                        .HasName("IX_Product_3");

                    b.HasIndex("SizeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Clothes_Shop.Models.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ShipperID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("char(9)")
                        .IsFixedLength(true)
                        .HasMaxLength(9)
                        .IsUnicode(false);

                    b.HasKey("ShipperId");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("Clothes_Shop.Models.SizeTab", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SizeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("SizeId");

                    b.HasIndex("SizeName")
                        .HasName("IX_SizeTab");

                    b.ToTable("SizeTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.StreetTab", b =>
                {
                    b.Property<int>("StreetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StreetID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("StreetId");

                    b.HasIndex("StreetName")
                        .HasName("IX_StreetTab");

                    b.ToTable("StreetTab");
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("Clothes_Shop.Models.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("Clothes_Shop.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUserTokens", b =>
                {
                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.AspNetUsers", b =>
                {
                    b.HasOne("Clothes_Shop.Models.CityTab", "City")
                        .WithMany("AspNetUsers")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_AspNetUsers_CityTab")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.StreetTab", "Street")
                        .WithMany("AspNetUsers")
                        .HasForeignKey("StreetId")
                        .HasConstraintName("FK_AspNetUsers_StreetTab")
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.Basket", b =>
                {
                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("Basket")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Basket_AspNetUsers")
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.BasketDetails", b =>
                {
                    b.HasOne("Clothes_Shop.Models.Basket", "Basket")
                        .WithMany("BasketDetails")
                        .HasForeignKey("BasketId")
                        .HasConstraintName("FK_BasketDetails_Basket")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.Product", "Product")
                        .WithMany("BasketDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_BasketDetails_Product")
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.Opinion", b =>
                {
                    b.HasOne("Clothes_Shop.Models.Product", "Product")
                        .WithMany("Opinion")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Opinion_Product")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("Opinion")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Opinion_AspNetUsers")
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.OrderDetails", b =>
                {
                    b.HasOne("Clothes_Shop.Models.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderDetails_Order")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_OrderDetails_Product")
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.Orders", b =>
                {
                    b.HasOne("Clothes_Shop.Models.Shipper", "Shipper")
                        .WithMany("Orders")
                        .HasForeignKey("ShipperId")
                        .HasConstraintName("FK_Order_Shipper")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.AspNetUsers", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Orders_AspNetUsers")
                        .IsRequired();
                });

            modelBuilder.Entity("Clothes_Shop.Models.Product", b =>
                {
                    b.HasOne("Clothes_Shop.Models.BrandTab", "Brand")
                        .WithMany("Product")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_Product_BrandTab")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.CategoryTab", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_CategoryTab")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.ColorTab", "Color")
                        .WithMany("Product")
                        .HasForeignKey("ColorId")
                        .HasConstraintName("FK_Product_ColorName")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.GenderTab", "Gender")
                        .WithMany("Product")
                        .HasForeignKey("GenderId")
                        .HasConstraintName("FK_Product_GenderTab")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.MaterialTab", "Material")
                        .WithMany("Product")
                        .HasForeignKey("MaterialId")
                        .HasConstraintName("FK_Product_MaterialTab")
                        .IsRequired();

                    b.HasOne("Clothes_Shop.Models.SizeTab", "Size")
                        .WithMany("Product")
                        .HasForeignKey("SizeId")
                        .HasConstraintName("FK_Product_SizeTab")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
