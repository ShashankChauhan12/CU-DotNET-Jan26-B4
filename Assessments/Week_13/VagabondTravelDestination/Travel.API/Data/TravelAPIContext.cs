using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travel.API.Models;

namespace Travel.API.Data
{
    public class TravelAPIContext : DbContext
    {
        public TravelAPIContext (DbContextOptions<TravelAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(p => p.CityName)
                      .IsRequired();

                entity.Property(p => p.Country)
                      .IsRequired();

                entity.Property(p => p.Description)
                      .HasMaxLength(200);

                entity.Property(p => p.Rating)
                      .HasDefaultValue(3);
            });
        }

        
        public DbSet<Travel.API.Models.Destination> Destination { get; set; } = default!;
    }
}
