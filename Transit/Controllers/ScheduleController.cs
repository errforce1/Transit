using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transit.Dto;
using Transit.Services;

namespace Transit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IEnumerable<StopDto>> Get()
        {
            return await _scheduleService.ListAllStops();
        }

        [HttpGet("{stopNumber}/{browserTime}")]
        public async Task<IActionResult> Get([FromRoute] short stopNumber, [FromRoute] DateTimeOffset browserTime)
        {
            var schedule = await _scheduleService.GetNextStopScheduleByTime(stopNumber, browserTime.DateTime);
            if (null == schedule)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
    }
}
