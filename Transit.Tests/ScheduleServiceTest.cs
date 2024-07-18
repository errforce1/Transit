using System;
using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using Transit.Models;
using Transit.Repository;
using Transit.Services;

namespace Transit.Tests
{
    public class ScheduleServiceTest
    {
        private Mock<IScheduleRepository> _scheduleRepository;

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
            _scheduleRepository = new Mock<IScheduleRepository>();
        }

        [TearDown]
        public void Cleanup()
        {
            _scheduleRepository = null;
        }

        [Test]
        public async Task ListAllStops_Should_Call_GetAllStops_Once_And_Return_Stops()
        {
            // Arrange
            _scheduleRepository.Setup(repo => repo.GetAllStops()).ReturnsAsync(_testStops);
            var scheduleService = new ScheduleService(_scheduleRepository.Object);

            // Act
            var stops = (await scheduleService.ListAllStops()).ToList();
            
            // Assert
            _scheduleRepository.Verify(repo => repo.GetAllStops(), Times.Once);
            Assert.AreEqual(2, stops.Count);
        }

        [Test]
        public async Task GetNextStopScheduleByTime_Should_Call_GetSchedulesByStopNumber_Once()
        {
            // Arrange
            _scheduleRepository.Setup(repo => repo.GetSchedulesByStopNumber(10)).ReturnsAsync(_testSchedules.Where(s => s.StopNumber == 10));
            var scheduleService = new ScheduleService(_scheduleRepository.Object);

            // Act
            var schedules = (await scheduleService.GetNextStopScheduleByTime(10, DateTime.Now));
            
            // Assert
            _scheduleRepository.Verify(repo => repo.GetSchedulesByStopNumber(10), Times.Once);
        }

        [Test]
        public async Task GetNextStopScheduleByTime_Should_Return_Next_Schedule_When_Valid_StopNumber_And_Valid_Time_Specified()
        {
            // Arrange
            _scheduleRepository.Setup(repo => repo.GetSchedulesByStopNumber(10)).ReturnsAsync(_testSchedules.Where(s => s.StopNumber == 10));
            var scheduleService = new ScheduleService(_scheduleRepository.Object);

            // Act
            var schedule = await scheduleService.GetNextStopScheduleByTime(10, getTodaysDateAtHour(6));
            
            // Assert
            Assert.IsNotNull(schedule);
            Assert.AreEqual(0600, schedule.Timepoint);
        }
        
        [Test]
        public async Task GetNextStopScheduleByTime_Should_Return_Null_When_Valid_StopNumber_And_Invalid_Time_Specified()
        {
            // Arrange
            _scheduleRepository.Setup(repo => repo.GetSchedulesByStopNumber(10)).ReturnsAsync(_testSchedules.Where(s => s.StopNumber == 10));
            var scheduleService = new ScheduleService(_scheduleRepository.Object);

            // Act
            var schedule = await scheduleService.GetNextStopScheduleByTime(10, getTodaysDateAtHour(23));
            
            // Assert
            Assert.IsNull(schedule);
        }
        
        [Test]
        public async Task GetNextStopScheduleByTime_Should_Return_Null_When_Invalid_StopNumber_And_Valid_Time_Specified()
        {
            // Arrange
            _scheduleRepository.Setup(repo => repo.GetSchedulesByStopNumber(10)).ReturnsAsync(_testSchedules.Where(s => s.StopNumber == 10));
            var scheduleService = new ScheduleService(_scheduleRepository.Object);

            // Act
            var schedule = await scheduleService.GetNextStopScheduleByTime(100, getTodaysDateAtHour(6));
            
            // Assert
            Assert.IsNull(schedule);
        }
        
        [Test]
        public async Task GetNextStopScheduleByTime_Should_Return_Null_When_Invalid_StopNumber_And_Invalid_Time_Specified()
        {
            // Arrange
            _scheduleRepository.Setup(repo => repo.GetSchedulesByStopNumber(10)).ReturnsAsync(_testSchedules.Where(s => s.StopNumber == 10));
            var scheduleService = new ScheduleService(_scheduleRepository.Object);

            // Act
            var schedule = await scheduleService.GetNextStopScheduleByTime(100, getTodaysDateAtHour(23));
            
            // Assert
            Assert.IsNull(schedule);
        }

        private DateTime getTodaysDateAtHour(int hour)
        {
            var today = DateTime.Today;
            return new DateTime(today.Year, today.Month, today.Day, hour, 00, 00);
        }
    }
}
