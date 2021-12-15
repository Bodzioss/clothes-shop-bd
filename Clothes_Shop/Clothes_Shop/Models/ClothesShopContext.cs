using Clothes_Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Data
{
    public class ClothesShopContext : DbContext
    {
        
        public ClothesShopContext(DbContextOptions<ClothesShopContext> options) : base(options)
        {

        }


        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketDetails> BasketDetails { get; set; }
        public DbSet<BrandTab> BrandTabs { get; set; }
        public DbSet<CategoryTab> CategoryTabs { get; set; }
        public DbSet<CityTab> CityTabs { get; set; }
        public DbSet<ColorTab> ColorTabs { get; set; }
        public DbSet<GenderTab> GenderTabs { get; set; }
        public DbSet<MaterialTab> MaterialTabs { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<SizeTab> SizeTabs { get; set; }
        public DbSet<StreetTab> StreetTabs { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
