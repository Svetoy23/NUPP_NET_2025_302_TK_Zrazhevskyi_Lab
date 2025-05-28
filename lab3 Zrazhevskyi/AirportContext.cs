using Microsoft.EntityFrameworkCore;
using Airport.Infrastructure.Models;

namespace Airport.Infrastructure
{
    public class AirportContext : DbContext
    {
        public DbSet<FlightModel> Flights { get; set; }
        public DbSet<AirplaneModel> Airplanes { get; set; }

        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AirplaneModel>()
                .HasMany(a => a.Flights)
                .WithOne(f => f.Airplane)
                .HasForeignKey(f => f.AirplaneId);
        }
    }
}