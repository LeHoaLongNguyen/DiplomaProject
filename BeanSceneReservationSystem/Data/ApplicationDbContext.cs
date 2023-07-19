using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace BeanSceneReservationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationSource> ReservationSources { get; set; }
        public DbSet<ReservationStatus> ReservationStatus { get; set; }
        public DbSet<RestaurantTable> RestaurantTables { get; set; }
        public DbSet<Sitting> Sittings { get; set; }

        public DbSet<ReservationTable> ReservationsTable { get; set; }
        public DbSet<SittingType> SittingTypes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new SeedingRestaurantData(builder);
            new SeedingUsersAndRoles(builder);
          
        }
 
    }
}