using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;
using ACR2.Core.Models;
using System.Linq;

namespace ACR2.Persistence
{
    public class WeekEntryRepository : IWeekEntryRepository
    {
        private readonly ACRDbContext context;
        public WeekEntryRepository(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<WeekEntry>> GetAllEntries(Filter filter)
        {
            var query = context.WeekEntry.Include(e => e.Category).Include(e => e.Week).AsQueryable();

            if (filter.Quarter.HasValue)
                query = query.Where(e => e.Week.Quarter == filter.Quarter.Value);

            if (filter.Week.HasValue)
                query = query.Where(e => e.Week.Number == filter.Week.Value);

            if (filter.Category.HasValue)
                query = query.Where(e => e.CategoryId == filter.Category.Value);

            return await query.ToListAsync();
        }

        public async Task<WeekEntry> GetEntryById(int id, bool loadFull = true)
        {
            if (!loadFull)
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

        public void UpdateEntry(WeekEntry entry)
        {
            context.WeekEntry.Update(entry);
        }
    }
}