﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Clothes_Shop.Models
{
    public partial class BD2SklepContext : DbContext
    {
        public BD2SklepContext()
        {
        }

        public BD2SklepContext(DbContextOptions<BD2SklepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<BasketDetails> BasketDetails { get; set; }
        public virtual DbSet<BrandTab> BrandTab { get; set; }
        public virtual DbSet<CategoryTab> CategoryTab { get; set; }
        public virtual DbSet<CityTab> CityTab { get; set; }
        public virtual DbSet<ClientAddress> ClientAddress { get; set; }
        public virtual DbSet<ColorTab> ColorTab { get; set; }
        public virtual DbSet<GenderTab> GenderTab { get; set; }
        public virtual DbSet<MaterialTab> MaterialTab { get; set; }
        public virtual DbSet<Opinion> Opinion { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Shipper> Shipper { get; set; }
        public virtual DbSet<SizeTab> SizeTab { get; set; }
        public virtual DbSet<StreetTab> StreetTab { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AMGTN3U;Database=BD2.Sklep;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.Property(e => e.BasketId).HasColumnName("BasketID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Basket)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Basket_User");
            });

            modelBuilder.Entity<BasketDetails>(entity =>
            {
                entity.Property(e => e.BasketDetailsId).HasColumnName("BasketDetailsID");

                entity.Property(e => e.BasketId).HasColumnName("BasketID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketDetails)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketDetails_Basket");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BasketDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketDetails_Product");
            });

            modelBuilder.Entity<BrandTab>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.HasIndex(e => e.BrandName)
                    .HasName("IX_BrandTab");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CategoryTab>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasIndex(e => e.CategoryName)
                    .HasName("IX_CategoryTab");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Picture)
                    .HasMaxLength(2048)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CityTab>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.HasIndex(e => e.CityName)
                    .HasName("IX_CityTab");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.Property(e => e.ClientAddressId).HasColumnName("ClientAddressID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.HomeNumber)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsMain).HasColumnName("isMain");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ClientAddress)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_CityTab1");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.ClientAddress)
                    .HasForeignKey(d => d.StreetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_StreetTab");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClientAddress)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_User");
            });

            modelBuilder.Entity<ColorTab>(entity =>
            {
                entity.HasKey(e => e.ColorId)
                    .HasName("PK_ColorName");

                entity.HasIndex(e => e.ColorName)
                    .HasName("IX_ColorTab");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.ColorName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<GenderTab>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.HasIndex(e => e.GenderName)
                    .HasName("IX_GenderTab");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<MaterialTab>(entity =>
            {
                entity.HasKey(e => e.MaterialId);

                entity.HasIndex(e => e.MaterialName)
                    .HasName("IX_MaterialTab");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Opinion>(entity =>
            {
                entity.Property(e => e.OpinionId).HasColumnName("OpinionID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Opinion)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opinion_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Opinion)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Opinion_User");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Product");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order");

                entity.HasIndex(e => e.OrderDate)
                    .HasName("IX_Orders_1");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ShipDate).HasColumnType("date");

                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Shipper");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Amount)
                    .HasName("IX_Product_5");

                entity.HasIndex(e => e.Pattern)
                    .HasName("IX_Product_4");

                entity.HasIndex(e => e.Price)
                    .HasName("IX_Product_1");

                entity.HasIndex(e => e.ProductName)
                    .HasName("IX_Product_2");

                entity.HasIndex(e => e.Season)
                    .HasName("IX_Product_3");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ColorId).HasColumnName("ColorID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.Pattern)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Picture).HasMaxLength(2048);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_BrandTab");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_CategoryTab");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ColorName");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_GenderTab");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_MaterialTab");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_SizeTab");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SizeTab>(entity =>
            {
                entity.HasKey(e => e.SizeId);

                entity.HasIndex(e => e.SizeName)
                    .HasName("IX_SizeTab");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StreetTab>(entity =>
            {
                entity.HasKey(e => e.StreetId);

                entity.HasIndex(e => e.StreetName)
                    .HasName("IX_StreetTab");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_User_5");

                entity.HasIndex(e => e.FirstName)
                    .HasName("IX_User_1");

                entity.HasIndex(e => e.LastName)
                    .HasName("IX_User_3");

                entity.HasIndex(e => e.Login)
                    .HasName("IX_User_7")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("IX_User_4");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(130)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StreetId).HasColumnName("StreetID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
