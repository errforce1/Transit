using System.Collections.Generic;
using System.Threading.Tasks;
using Transit.Models;

namespace Transit.Repository
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Stop>> GetAllStops();
        Task<IEnumerable<Schedule>> GetSchedulesByStopNumber(long stopNumber);
    }
}