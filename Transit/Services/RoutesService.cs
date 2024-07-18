using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transit.Dto;
using Transit.Repository;

namespace Transit.Services
{
    public class RoutesService : IRoutesService
    {
        protected IRoutesRepository _routesRepository;
        
        public RoutesService(IRoutesRepository routesRepository)
        {
            _routesRepository = routesRepository;
        }
        
        public async Task<IEnumerable<RouteStopDto>> ListAllStops()
        {
            return (await _routesRepository.GetAllStops())
                .Select(routeStop => new RouteStopDto()
                {
                    Id = routeStop.Id,
                    Name = routeStop.Name,
                    Number = routeStop.Number
                });
        }

        public async Task<RouteScheduleDto> GetNextStopScheduleByTime(short stopNumber, DateTime time)
        {
            var shortTimeCode = GetShortTimeCode(time);
            return (await _routesRepository.GetSchedulesByStopNumber(stopNumber))
                .Select(schedule => new RouteScheduleDto()
                {
                    Id = schedule.Id,
                    StopNumber = schedule.StopNumber,
                    Timepoint = schedule.Timepoint
                })
                .FirstOrDefault(schedule => schedule.Timepoint >= shortTimeCode);
        }

        protected short GetShortTimeCode(DateTime time)
        {
            return short.Parse($"{time:HHmm}");
        }
    }
}
