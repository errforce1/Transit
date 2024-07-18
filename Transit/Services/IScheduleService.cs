using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transit.Dto;
using Transit.Models;

namespace Transit.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<StopDto>> ListAllStops();
        Task<ScheduleDto> GetNextStopScheduleByTime(short stopNumber, DateTime time);
    }
}