using E_Apoteka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_Apoteka.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<MedicineCategory> MedicineCategory { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescription { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCart> ProductCart { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<MedicineCategory>().ToTable("MedicineCategory");
            modelBuilder.Entity<MedicinePrescription>().ToTable("MedicinePrescription");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Prescription>().ToTable("Prescription");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCart>().ToTable("ProductCart");
            modelBuilder.Entity<ProductOrder>().ToTable("ProductOrder");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<User>().ToTable("User");

            base.OnModelCreating(modelBuilder);
        }
    }
}