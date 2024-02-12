using Azure;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Database
{
    public class AirportDbContext(DbContextOptions<AirportDbContext> options) : DbContext(options), IAirportDbContext
    {
        public DbSet<Country> GeographyLevel1 { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<AirportGroup> AirportGroup { get; set; }
        public DbSet<AirportsToAirportGroupsJoins> AirportsToAirportGroupsJoins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasKey(b => b.GeographyLevel1Id)
                .HasName("Pk_GeographyLevel1Id");
            modelBuilder.Entity<Country>().HasAlternateKey(p => p.Name);
            modelBuilder.Entity<Country>().Property(p => p.GeographyLevel1Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(p => p.AirportId);
                entity.Property(p=>p.AirportId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Airport>()
                .HasOne(p => p.Country)
                .WithMany(p => p.Airports)
                .HasForeignKey(p=>p.GeographyLevel1Id);

           

            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(p => p.RouteId);
                entity.Property(p=>p.RouteId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AirportGroup>()
                .HasKey(p => p.AirportGroupId);

            modelBuilder.Entity<AirportGroup>()
               .HasMany(p => p.Airports)
               .WithMany(p => p.AirportGroups)
               .UsingEntity<AirportsToAirportGroupsJoins>(
                    p => p.HasOne<Airport>().WithMany().HasForeignKey(e => e.AirportId),
                    q => q.HasOne<AirportGroup>().WithMany().HasForeignKey(e => e.AirportGroupId));

        }
        public async Task SaveAsync()
        {
            try
            {
                await base.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
