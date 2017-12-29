using System;
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
    [Route("/api/weekentries")]
    public class WeekEntryController : Controller
    {
        private readonly ACRDbContext context;
        private readonly IMapper mapper;
        public WeekEntryController(ACRDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<WeekEntryResource>> GetWeekEntries()
        {
            var entries = await context.WeekEntry.Include(e => e.Category).Include(e => e.Week).ToListAsync();

            var result = mapper.Map<List<WeekEntry>, List<WeekEntryResource>>(entries);

            return result;
                
        }

        [HttpPost("post")]
        public async Task<IActionResult> CreateWeekEntry([FromBody] WeekEntryResource entryResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await context.Category.FindAsync(entryResource.Category.Id);
            var week = await context.Week.FindAsync(entryResource.Week.Id);
            if (category == null)
            {
                ModelState.AddModelError("Category", "Invalid category.");
                return BadRequest(ModelState);
            }
            if (week == null)
            {
                ModelState.AddModelError("Week", "Invalid week.");
                return BadRequest(ModelState);
            }

            var entry = mapper.Map<WeekEntryResource, WeekEntry>(entryResource);
            entry.LastUpdated = DateTime.Now;

            context.WeekEntry.Add(entry);
            await context.SaveChangesAsync();

            var result = mapper.Map<WeekEntry, WeekEntryResource>(entry);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeekEntry(int id, [FromBody] WeekEntryResource entryResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var entry = await context.WeekEntry.Include(e => e.Category).Include(e => e.Week).SingleOrDefaultAsync(e => e.Id == id); 
            
            if(entry == null)
                return NotFound();
            
            mapper.Map<WeekEntryResource, WeekEntry>(entryResource);
            entry.LastUpdated = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<WeekEntry, WeekEntryResource>(entry);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeekEntry(int id)
        {
            var entry = await context.WeekEntry.FindAsync(id);

            if(entry == null)
                return NotFound();
            
            context.Remove(entry);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeekEntry(int id)
        {
            var entry = await context.WeekEntry.Include(e => e.Category).Include(e => e.Week).SingleOrDefaultAsync(e => e.Id == id);

            if(entry == null)
                return NotFound();

            var entryResource = mapper.Map<WeekEntry, WeekEntryResource>(entry);

            return Ok(entryResource);
        }
    }
}