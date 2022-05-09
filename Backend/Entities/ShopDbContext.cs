using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options):base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.HasOne(x => x.Category).WithMany(x => x.Products)
                .HasForeignKey(x => x.CateID).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Order>(p =>
            {
                p.HasOne(x => x.Customer).WithMany(x => x.orders)
                .HasForeignKey(x => x.CustomerID).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<OrderDetail>(p =>
            {
                p.HasOne(x => x.Product).WithMany(x => x.orderDetails)
                .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);
                p.HasOne(x => x.Order).WithMany(x => x.orderDetails)
               .HasForeignKey(x => x.OrderID).OnDelete(DeleteBehavior.Cascade);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
