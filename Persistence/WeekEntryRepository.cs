using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;

namespace ACR2.Persistence
{
    public class WeekEntryRepository : IWeekEntryRepository
    {
        private readonly ACRDbContext context;
        public WeekEntryRepository(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<WeekEntry>> GetAllEntries()
        {
            return await context.WeekEntry.Include(e => e.Category).Include(e => e.Week).ToListAsync();
        }

        public async Task<WeekEntry> GetEntryById(int id, bool loadFull = true)
        {
            if(!loadFull)
                return await context.WeekEntry.FindAsync(id);

            return await context.WeekEntry
                .Include(e => e.Category)
                .Include(e => e.Week)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public void AddEntry(WeekEntry entry)
        {
            context.WeekEntry.Add(entry);
        }

        public void RemoveEntry(WeekEntry entry)
        {
            context.WeekEntry.Remove(entry);
        }
    }
}