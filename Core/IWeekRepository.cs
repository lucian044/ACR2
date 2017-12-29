using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Models;

namespace ACR2.Core
{
    public interface IWeekRepository
    {
         Task<IEnumerable<Week>> GetAllWeeks();

         Task<Week> GetWeekById(int id);
    }
}