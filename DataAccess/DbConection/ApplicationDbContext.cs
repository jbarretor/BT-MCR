using Microsoft.EntityFrameworkCore;
using MilesCarRental.Models;

namespace DataAccess.DbConection.DbConection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Car>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<CarRental>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Client>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Car>()
                .HasOne(m => m.Location)
                .WithMany(g => g.Cars)
                .HasForeignKey(s => s.LocationId);

            modelBuilder.Entity<CarRental>()
                .HasOne(m => m.Client)
                .WithMany(g => g.Rentals)
                .HasForeignKey(s => s.ClientId);

            modelBuilder.Entity<CarRental>()
                .HasOne(m => m.PickupLocation)
                .WithMany(g => g.PickupLocation)
                .HasForeignKey(s => s.PickupLocationId);

            modelBuilder.Entity<CarRental>()
                .HasOne(m => m.ReturnLocation)
                .WithMany(g => g.ReturnLocation)
                .HasForeignKey(s => s.ReturnLocationId);

            modelBuilder.Entity<Car>()
                .HasOne(m => m.Location)
                .WithMany(g => g.Cars)
                .HasForeignKey(s => s.LocationId);
        }
    }
}
