using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Transit.Models;

namespace Transit.Data
{
    public class TransitDataContext : DbContext
    {
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public TransitDataContext(DbContextOptions<TransitDataContext> options) : base(options)
        {
        }

        // Used to automatically generate identities for a set of database records
        private IEnumerable<T> AssignUniqueIds<T>(params T[] entities) where T : class, IEntity
        {
            int id = 1;
            return entities.Select(entity =>
            {
                entity.Id = id++;
                return entity;
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify foreign key relationship and multiplicity
            modelBuilder.Entity<Schedule>()
                .HasOne(schedule => schedule.Stop)
                .WithMany(stop => stop.Schedules)
                .HasForeignKey(schedule => schedule.StopNumber)
                .HasPrincipalKey(stop => stop.Number);

            // Generate unique index
            modelBuilder.Entity<Stop>()
                .HasIndex(entity => entity.Number)
                .IsUnique();

            // Combined southbound and northbound stops of F route
            var stops = new[]
            {
                new Stop { Order = 1, Number = 6041, Name = "Southbound - Beaudry Ave & 3rd St" },
                new Stop { Order = 2, Number = 6138, Name = "Southbound - 4th St & Figueroa St" },
                new Stop { Order = 3, Number = 6021, Name = "Southbound - Flower St & 5th St" },
                new Stop { Order = 4, Number = 6139, Name = "Southbound - Flower St & 7th St" },
                new Stop { Order = 5, Number = 6140, Name = "Southbound - Flower St & 8th St" },
                new Stop { Order = 6, Number = 9638, Name = "Southbound - Flower St & 9th St" },
                new Stop { Order = 7, Number = 6142, Name = "Southbound - Flower St & Olympic Blvd" },
                new Stop { Order = 8, Number = 6143, Name = "Southbound - Figueroa & 12th St (Crypto.com Arena)" },
                new Stop { Order = 9, Number = 6144, Name = "Southbound - Figueroa St & Pico Blvd" },
                new Stop { Order = 10, Number = 6145, Name = "Southbound - Figueroa St & Venice Blvd" },
                new Stop { Order = 11, Number = 6146, Name = "Southbound - Figueroa St & Washington Blvd" },
                new Stop { Order = 12, Number = 6147, Name = "Southbound - Figueroa St & 23rd St" },
                new Stop { Order = 13, Number = 6148, Name = "Southbound - Figueroa St & Adams Blvd" },
                new Stop { Order = 14, Number = 6149, Name = "Southbound - Figueroa St & 30th St" },
                new Stop { Order = 15, Number = 6150, Name = "Southbound - Figueroa St & Jefferson Blvd" },
                new Stop { Order = 16, Number = 6151, Name = "Southbound - Figueroa St & McCarthy Way" },
                new Stop { Order = 17, Number = 6216, Name = "Southbound - Exposition Blvd & Trousdale Pkwy" },
                new Stop { Order = 18, Number = 6152, Name = "Southbound - Exposition Blvd & Watt Way" },
                new Stop { Order = 19, Number = 6040, Name = "Northbound - Vermont Ave & Exposition Blvd" },
                new Stop { Order = 20, Number = 6119, Name = "Northbound - Vermont Ave & 37th Pl" },
                new Stop { Order = 21, Number = 6120, Name = "Northbound - Vermont Ave & 36th Pl" },
                new Stop { Order = 22, Number = 6121, Name = "Northbound - Jefferson Blvd & Vermont Ave" },
                new Stop { Order = 23, Number = 6122, Name = "Northbound - Jefferson Blvd & McClintock Ave" },
                new Stop { Order = 24, Number = 6123, Name = "Northbound - Jefferson Blvd & Hoover St" },
                new Stop { Order = 25, Number = 6124, Name = "Northbound - Figueroa St & 33rd St" },
                new Stop { Order = 26, Number = 6125, Name = "Northbound - Figueroa St & 30th St" },
                new Stop { Order = 27, Number = 6126, Name = "Northbound - Figueroa St & Adams Blvd" },
                new Stop { Order = 28, Number = 6127, Name = "Northbound - Figueroa St & 23rd St" },
                new Stop { Order = 29, Number = 6128, Name = "Northbound - Figueroa St & Washington Blvd" },
                new Stop { Order = 30, Number = 6129, Name = "Northbound - Figueroa St & Venice Blvd" },
                new Stop { Order = 31, Number = 6130, Name = "Northbound - Figueroa St & 12th St" },
                new Stop { Order = 32, Number = 6132, Name = "Northbound - Figueroa & 11th St (Crypto.com Arena)" },
                new Stop { Order = 33, Number = 6133, Name = "Northbound - Figueroa St & Olympic Blvd" },
                new Stop { Order = 34, Number = 6135, Name = "Northbound - Figueroa St & 8th St" },
                new Stop { Order = 35, Number = 6136, Name = "Northbound - Figueroa St & 7th St" },
                new Stop { Order = 36, Number = 6137, Name = "Northbound - Figueroa St & 5th St" }
            };

            // Add Stops Data
            modelBuilder.Entity<Stop>().HasData(
                AssignUniqueIds(
                    stops
                )
            );

            // Add Schedule Data
            modelBuilder.Entity<Schedule>().HasData(
                AssignUniqueIds(
                    generateSchedules(stops)
                        .ToArray()
                )
            );
        }

        private IEnumerable<Schedule> generateSchedules(IEnumerable<Stop> stops)
        {
            // Determine number of intervals to generate, 15 hours (6am - 9pm) divided by 10 minute chunks
            var intervals = ((15 * 60) / 10);

            var routeStops = stops.ToList();

            // Determine the number of stop sets that should be used for schedule generation
            var iterations = (int)Math.Ceiling((double)intervals / routeStops.Count);

            // Generate set of schedules with timepoints calculated at 10 minute intervals using sets of stops 
            return Enumerable.Repeat(routeStops, iterations)
                .SelectMany(routeStop => routeStop)
                .Take(intervals)
                .Select((stop, interval) => new Schedule()
                {
                    StopNumber = stop.Number,
                    Timepoint = short.Parse($"{TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(10 * interval)):hhmm}")
                });
        }
    }
}
