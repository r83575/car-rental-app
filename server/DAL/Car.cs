using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Car:DbContext
    {
        public Car(DbContextOptions<Car> options) : base(options)
        {

        }
      
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<PurchaseRental> PurchaseRentals { get; set; }
    }
}