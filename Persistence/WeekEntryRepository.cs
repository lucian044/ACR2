using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;
using ACR2.Core.Models;
using System.Linq;
using System.Linq.Expressions;
using System;
using ACR2.Extensions;

namespace ACR2.Persistence
{
    public class WeekEntryRepository : IWeekEntryRepository
    {
        private readonly ACRDbContext context;
        public WeekEntryRepository(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task<QueryResult<WeekEntry>> GetAllEntries(WeekEntryQuery queryObj)
        {
            var result = new QueryResult<WeekEntry>();
            var query = context.WeekEntry.Include(e => e.Category).Include(e => e.Week).AsQueryable();

            if (queryObj.Quarter.HasValue)
                query = query.Where(e => e.Week.Quarter == queryObj.Quarter.Value);

            if (queryObj.Week.HasValue)
                query = query.Where(e => e.Week.Number == queryObj.Week.Value);

            if (queryObj.Category.HasValue)
                query = query.Where(e => e.CategoryId == queryObj.Category.Value);
            query = query.Where(e => e.Auth0Id == queryObj.Auth0Id);


            var columnsMap = new Dictionary<string, Expression<Func<WeekEntry, object>>>()
            {
                ["quarter"] = e => e.Week.Quarter,
                ["week"] = e => e.Week.Number,
                ["category"] = e => e.Category.Id
            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);
            
            result.Items = await query.ToListAsync();

            return result;
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