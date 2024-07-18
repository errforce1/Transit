using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Transit.Data;
using Transit.Models;

namespace Transit.Repository
{
    public class RoutesRepository : IRoutesRepository
    {
        protected TransitDataContext _transitDataContext;
        
        public RoutesRepository(TransitDataContext transitDataContext)
        {
            _transitDataContext = transitDataContext;
        }
        
        public async Task<IEnumerable<RouteStop>> GetAllStops()
        {
            return await _transitDataContext.RouteStops.OrderBy(routeStop => routeStop.Order).ToListAsync();
        }
        
        public async Task<IEnumerable<RouteSchedule>> GetSchedulesByStopNumber(long stopNumber)
        {
            return await _transitDataContext.RouteSchedules.Where(routeSchedule =>
                routeSchedule.StopNumber == stopNumber).ToListAsync();
        }
    }
}
