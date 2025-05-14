using E_commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Dal;

public class MainContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Card> Cards { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("connectionString here");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<Order>(entity =>
        //{
        //    entity.ToTable("Orders");
        //}
        //);
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<Card>().ToTable("Card");
        modelBuilder.Entity<Cart>().ToTable("Cart");
        modelBuilder.Entity<CartProduct>().ToTable("CartProduct");
        modelBuilder.Entity<OrderProduct>().ToTable("OrderProduct");
        modelBuilder.Entity<OrderStatus>().ToTable("OrderStatus");
        modelBuilder.Entity<Payment>().ToTable("Payment");
        modelBuilder.Entity<Product>().ToTable("Product");
        //modelBuilder.Entity<Product>().ToTable("Product", "dbo");

        //modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}
