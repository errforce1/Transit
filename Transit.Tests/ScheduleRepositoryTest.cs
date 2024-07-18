using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Transit.Data;
using System.Threading.Tasks;
using Transit.Models;
using Transit.Repository;

namespace Transit.Tests
{
    public class ScheduleRepositoryTest
    {
        private TransitDataContext _transitDataContext;

        private readonly System.Collections.Generic.List<Stop> _testStops = new()
        {
            new Stop() { Id = 10000, Number = 10, Name = "TEST1", Order = 1 },
            new Stop() { Id = 10001, Number = 20, Name = "TEST2", Order = 2 }
        };

        private readonly System.Collections.Generic.List<Schedule> _testSchedules = new()
        {
            new Schedule() { Id = 10001, StopNumber = 10, Timepoint = 0600 },
            new Schedule() { Id = 10002, StopNumber = 20, Timepoint = 0610 },
            new Schedule() { Id = 10003, StopNumber = 10, Timepoint = 0620 },
            new Schedule() { Id = 10004, StopNumber = 20, Timepoint = 0630 }
        };

        [SetUp]
        public void Setup()
        {
            var databaseOptions = new DbContextOptionsBuilder<TransitDataContext>()
                .UseInMemoryDatabase("UNIT_TEST_DATABASE")
                .Options;
            
            _transitDataContext = new TransitDataContext(databaseOptions);
            _transitDataContext.Database.EnsureCreated();
            
            _transitDataContext.RemoveRange(_transitDataContext.Stops);
            _transitDataContext.RemoveRange(_transitDataContext.Schedules);
            
            _transitDataContext.AddRange(_testStops);
            _transitDataContext.AddRange(_testSchedules);
            _transitDataContext.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            _transitDataContext.Database.EnsureDeleted();
            _transitDataContext.Dispose();
            _transitDataContext = null;
        }

        [Test]
        public async Task GetAllStops_Should_Return_All_Populated_Stops()
        {
            // Arrange
            var scheduleRepository = new ScheduleRepository(_transitDataContext);

            // Act
            var stops = (await scheduleRepository.GetAllStops()).ToList();
            
            // Assert
            Assert.AreEqual(2, stops.Count);
        }

        [Test]
        public async Task GetSchedulesByStopNumber_Should_Return_Schedules_For_Stop_Number_When_Valid_Stop_Number_Specified()
        {
            // Arrange
            var scheduleRepository = new ScheduleRepository(_transitDataContext);

            // Act
            var schedules = (await scheduleRepository.GetSchedulesByStopNumber(10)).ToList();
            
            // Assert
            Assert.AreEqual(2, schedules.Count);
        }

        [Test]
        public async Task GetSchedulesByStopNumber_Should_Return_No_Schedules_For_Stop_Number_When_Invalid_Stop_Number_Specified()
        {
            // Arrange
            var scheduleRepository = new ScheduleRepository(_transitDataContext);

            // Act
            var schedules = (await scheduleRepository.GetSchedulesByStopNumber(100)).ToList();
            
            // Assert
            Assert.IsEmpty(schedules);
        }
    }
}
