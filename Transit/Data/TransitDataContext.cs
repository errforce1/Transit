using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Transit.Models;

namespace Transit.Data
{
    public class TransitDataContext : DbContext
    {
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<RouteSchedule> RouteSchedules { get; set; }

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
            modelBuilder.Entity<RouteSchedule>()
                .HasOne(routeSchedule => routeSchedule.RouteStop)
                .WithMany(routeStop => routeStop.RouteSchedules)
                .HasForeignKey(routeSchedule => routeSchedule.StopNumber)
                .HasPrincipalKey(routeStop => routeStop.Number);

            // Generate unique index
            modelBuilder.Entity<RouteStop>()
                .HasIndex(entity => entity.Number)
                .IsUnique();

            // Combined southbound and northbound stops of F route
            var stops = new[]
            {
                new RouteStop { Order = 1, Number = 6041, Name = "Beaudry Ave & 3rd St" },
                new RouteStop { Order = 2, Number = 6138, Name = "4th St & Figueroa St" },
                new RouteStop { Order = 3, Number = 6021, Name = "Flower St & 5th St" },
                new RouteStop { Order = 4, Number = 6139, Name = "Flower St & 7th St" },
                new RouteStop { Order = 5, Number = 6140, Name = "Flower St & 8th St" },
                new RouteStop { Order = 6, Number = 9638, Name = "Flower St & 9th St" },
                new RouteStop { Order = 7, Number = 6142, Name = "Flower St & Olympic Blvd" },
                new RouteStop { Order = 8, Number = 6143, Name = "Figueroa & 12th St (Crypto.com Arena)" },
                new RouteStop { Order = 9, Number = 6144, Name = "Figueroa St & Pico Blvd" },
                new RouteStop { Order = 10, Number = 6145, Name = "Figueroa St & Venice Blvd" },
                new RouteStop { Order = 11, Number = 6146, Name = "Figueroa St & Washington Blvd" },
                new RouteStop { Order = 12, Number = 6147, Name = "Figueroa St & 23rd St" },
                new RouteStop { Order = 13, Number = 6148, Name = "Figueroa St & Adams Blvd" },
                new RouteStop { Order = 14, Number = 6149, Name = "Figueroa St & 30th St" },
                new RouteStop { Order = 15, Number = 6150, Name = "Figueroa St & Jefferson Blvd" },
                new RouteStop { Order = 16, Number = 6151, Name = "Figueroa St & McCarthy Way" },
                new RouteStop { Order = 17, Number = 6216, Name = "Exposition Blvd & Trousdale Pkwy" },
                new RouteStop { Order = 18, Number = 6152, Name = "Exposition Blvd & Watt Way" },
                new RouteStop { Order = 19, Number = 6040, Name = "Vermont Ave & Exposition Blvd" },
                new RouteStop { Order = 20, Number = 6119, Name = "Vermont Ave & 37th Pl" },
                new RouteStop { Order = 21, Number = 6120, Name = "Vermont Ave & 36th Pl" },
                new RouteStop { Order = 22, Number = 6121, Name = "Jefferson Blvd & Vermont Ave" },
                new RouteStop { Order = 23, Number = 6122, Name = "Jefferson Blvd & McClintock Ave" },
                new RouteStop { Order = 24, Number = 6123, Name = "Jefferson Blvd & Hoover St" },
                new RouteStop { Order = 25, Number = 6124, Name = "Figueroa St & 33rd St" },
                new RouteStop { Order = 26, Number = 6125, Name = "Figueroa St & 30th St" },
                new RouteStop { Order = 27, Number = 6126, Name = "Figueroa St & Adams Blvd" },
                new RouteStop { Order = 28, Number = 6127, Name = "Figueroa St & 23rd St" },
                new RouteStop { Order = 29, Number = 6128, Name = "Figueroa St & Washington Blvd" },
                new RouteStop { Order = 30, Number = 6129, Name = "Figueroa St & Venice Blvd" },
                new RouteStop { Order = 31, Number = 6130, Name = "Figueroa St & 12th St" },
                new RouteStop { Order = 32, Number = 6132, Name = "Figueroa & 11th St (Crypto.com Arena)" },
                new RouteStop { Order = 33, Number = 6133, Name = "Figueroa St & Olympic Blvd" },
                new RouteStop { Order = 34, Number = 6135, Name = "Figueroa St & 8th St" },
                new RouteStop { Order = 35, Number = 6136, Name = "Figueroa St & 7th St" },
                new RouteStop { Order = 36, Number = 6137, Name = "Figueroa St & 5th St" }
            };

            // Add Stops Data
            modelBuilder.Entity<RouteStop>().HasData(
                AssignUniqueIds(
                    stops
                )
            );

            // Add Schedule Data
            modelBuilder.Entity<RouteSchedule>().HasData(
                AssignUniqueIds(
                    generateRouteSchedules(stops)
                        .ToArray()
                )
            );
        }

        private IEnumerable<RouteSchedule> generateRouteSchedules(IEnumerable<RouteStop> stops)
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
                .Select((stop, interval) => new RouteSchedule()
                {
                    StopNumber = stop.Number,
                    Timepoint = short.Parse($"{TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(10 * interval)):hhmm}")
                });
        }
    }
}
