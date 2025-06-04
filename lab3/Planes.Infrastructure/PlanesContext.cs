using Microsoft.EntityFrameworkCore;
using Warships.Infrastructure.Models;

namespace Warships.Infrastructure
{
    public class WarshipContext : DbContext
    {
        public DbSet<WarshipModel> Warships => Set<WarshipModel>();
        public DbSet<CaptainModel> Captains => Set<CaptainModel>();
        public DbSet<CrewMemberModel> CrewMembers => Set<CrewMemberModel>();

        public WarshipContext(DbContextOptions<WarshipContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarshipModel>()
                .HasOne(w => w.Captain)
                .WithOne(c => c.Warship)
                .HasForeignKey<WarshipModel>(w => w.CaptainId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WarshipModel>()
                .HasMany(w => w.CrewMembers)
                .WithOne(c => c.Warship)
                .HasForeignKey(c => c.WarshipModelId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
