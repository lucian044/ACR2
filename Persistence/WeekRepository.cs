using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;

namespace ACR2.Persistence
{
    public class WeekRepository : IWeekRepository
    {
        private readonly ACRDbContext context;
        public WeekRepository(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Week>> GetAllWeeks()
        {
            return await context.Week.Include(w => w.Entries).ToListAsync();
        }

        public async Task<Week> GetWeekById(int id)
        {
            return await context.Week.FindAsync(id);
        }
    }
}