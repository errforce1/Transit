using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Transit.Data;
using Transit.Models;

namespace Transit.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        protected TransitDataContext _transitDataContext;
        
        public ScheduleRepository(TransitDataContext transitDataContext)
        {
            _transitDataContext = transitDataContext;
        }
        
        public async Task<IEnumerable<Stop>> GetAllStops()
        {
            return await _transitDataContext.Stops.OrderBy(routeStop => routeStop.Order).ToListAsync();
        }
        
        public async Task<IEnumerable<Schedule>> GetSchedulesByStopNumber(long stopNumber)
        {
            return await _transitDataContext.Schedules.Where(routeSchedule =>
                routeSchedule.StopNumber == stopNumber).ToListAsync();
        }
    }
}
