using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Core.Models;
using ACR2.Models;

namespace ACR2.Core
{
    public interface IWeekEntryRepository
    {
         Task<IEnumerable<WeekEntry>> GetAllEntries(Filter filter);

         Task<WeekEntry> GetEntryById(int id, bool loadFull = true);

         void AddEntry(WeekEntry entry);

        void RemoveEntry(WeekEntry entry);

        void UpdateEntry(WeekEntry entry);

    }
}