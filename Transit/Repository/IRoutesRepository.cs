using System.Collections.Generic;
using System.Threading.Tasks;
using Transit.Models;

namespace Transit.Repository
{
    public interface IRoutesRepository
    {
        Task<IEnumerable<RouteStop>> GetAllStops();
        Task<IEnumerable<RouteSchedule>> GetSchedulesByStopNumber(long stopNumber);
    }
}