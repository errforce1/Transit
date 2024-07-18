using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transit.Dto;
using Transit.Repository;

namespace Transit.Services
{
    public class ScheduleService : IScheduleService
    {
        protected IScheduleRepository ScheduleRepository;
        
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            ScheduleRepository = scheduleRepository;
        }
        
        public async Task<IEnumerable<StopDto>> ListAllStops()
        {
            return (await ScheduleRepository.GetAllStops())
                .Select(stop => new StopDto()
                {
                    Id = stop.Id,
                    Name = stop.Name,
                    Number = stop.Number
                });
        }

        public async Task<ScheduleDto> GetNextStopScheduleByTime(short stopNumber, DateTime time)
        {
            var shortTimeCode = GetShortTimeCode(time);
            return (await ScheduleRepository.GetSchedulesByStopNumber(stopNumber))
                .Select(schedule => new ScheduleDto()
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
