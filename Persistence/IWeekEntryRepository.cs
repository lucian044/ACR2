using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Models;

namespace ACR2.Persistence
{
    public interface IWeekEntryRepository
    {
         Task<IEnumerable<WeekEntry>> GetAllEntries();

         Task<WeekEntry> GetEntryById(int id, bool loadFull = true);

         void AddEntry(WeekEntry entry);

        void RemoveEntry(WeekEntry entry);

    }
}