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
    public class RoutesController : ControllerBase
    {
        private readonly IRoutesService _routesService;

        public RoutesController(IRoutesService routesService)
        {
            _routesService = routesService;
        }

        [HttpGet]
        public async Task<IEnumerable<RouteStopDto>> Get()
        {
            return await _routesService.ListAllStops();
        }

        [HttpGet("{stopNumber}/{browserTime}")]
        public async Task<IActionResult> Get([FromRoute] short stopNumber, [FromRoute] DateTimeOffset browserTime)
        {
            var schedule = await _routesService.GetNextStopScheduleByTime(stopNumber, browserTime.DateTime);
            if (null == schedule)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
    }
}
