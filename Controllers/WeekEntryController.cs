using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Models.Resources;
using ACR2.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACR2.Controllers
{
    public class WeekEntryController : Controller
    {
        private readonly ACRDbContext context;
        private readonly IMapper mapper;
        public WeekEntryController(ACRDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/weekentries")]
        public async Task<IEnumerable<WeekEntryResource>> GetWeekEntries()
        {
            var entries = await context.WeekEntry.Include(w => w.Category).ToListAsync();

            return mapper.Map<List<WeekEntry>, List<WeekEntryResource>>(entries);
        }

        [HttpPost("/api/weekentries/post")]
        public IActionResult CreateWeekEntry([FromBody] WeekEntry entry)
        {
            return Ok(entry);
        }
    }
}