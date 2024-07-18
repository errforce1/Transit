using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transit.Dto;
using Transit.Models;

namespace Transit.Services
{
    public interface IRoutesService
    {
        Task<IEnumerable<RouteStopDto>> ListAllStops();
        Task<RouteScheduleDto> GetNextStopScheduleByTime(short stopNumber, DateTime time);
    }
}