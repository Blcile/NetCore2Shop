using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore2Shop.Models;

namespace NetCore2Shop.Data
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>().ToTable("Address").HasKey(c => c.Id);
            builder.Entity<Brand>().ToTable("Brand").HasKey(c => c.Id);
            builder.Entity<Category>().ToTable("Category").HasKey(c => c.Id);
            builder.Entity<City>().ToTable("City").HasKey(c => c.Id);
            builder.Entity<Comment>().ToTable("Comment").HasKey(c => c.Id);
            builder.Entity<Image>().ToTable("Image").HasKey(c => c.Id);
            builder.Entity<Order>().ToTable("Order").HasKey(c => c.Id);
            builder.Entity<OrderDetail>().ToTable("OrderDetail").HasKey(c => c.Id);
            builder.Entity<Product>().ToTable("Product").HasKey(c => c.Id);
            builder.Entity<Province>().ToTable("Province").HasKey(c => c.Id);
            builder.Entity<AppUser>().ToTable("AppUser").HasKey(c => c.Id);
            builder.Entity<Menu>().ToTable("Menu").HasKey(c => c.Id);
            builder.Entity<Role>().ToTable("Role").HasKey(c => c.Id);

            base.OnModelCreating(builder);
        }
    }
}