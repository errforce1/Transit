using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Transit.Controllers;
using Transit.Dto;
using Transit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Transit.Tests
{
    [TestFixture]
    public class ScheduleControllerTests
    {
        private Mock<IScheduleService> _mockScheduleService;
        private ScheduleController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockScheduleService = new Mock<IScheduleService>();
            _controller = new ScheduleController(_mockScheduleService.Object);
        }

        [Test]
        public async Task Get_Should_Return_List_Of_StopDto()
        {
            // Arrange
            var mockStops = new List<StopDto>
            {
                new() { Number = 1, Name = "Stop1" },
                new() { Number = 2, Name = "Stop2" }
            };
            _mockScheduleService.Setup(service => service.ListAllStops()).ReturnsAsync(mockStops);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<StopDto>>(result);
            Assert.AreEqual(2, ((List<StopDto>)result).Count);
        }

        [Test]
        public async Task Get_ByStopNumberAndBrowserTime_Should_Return_ScheduleDto()
        {
            // Arrange
            short stopNumber = 1;
            var browserTime = DateTimeOffset.Now;
            var mockSchedule = new ScheduleDto
            {
                StopNumber = stopNumber,
                Timepoint = short.Parse($"{browserTime.DateTime.AddMinutes(5):HHmm}")
            };
            _mockScheduleService.Setup(service => service.GetNextStopScheduleByTime(stopNumber, browserTime.DateTime))
                .ReturnsAsync(mockSchedule);

            // Act
            var result = await _controller.Get(stopNumber, browserTime);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<ScheduleDto>(okResult.Value);

            var schedule = okResult.Value as ScheduleDto;
            Assert.AreEqual(stopNumber, schedule?.StopNumber);
            Assert.AreEqual(mockSchedule.Timepoint, schedule.Timepoint);
        }

        [Test]
        public async Task Get_ByStopNumberAndBrowserTime_Should_Return_NotFound_When_Schedule_Is_Null()
        {
            // Arrange
            short stopNumber = 1;
            var browserTime = DateTimeOffset.Now;
            _mockScheduleService.Setup(service => service.GetNextStopScheduleByTime(stopNumber, browserTime.DateTime))
                .ReturnsAsync((ScheduleDto)null);

            // Act
            var result = await _controller.Get(stopNumber, browserTime) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
