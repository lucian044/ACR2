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
            var entries = await context.WeekEntry.ToListAsync();

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
            result.Category.Name = context.Category.Find(result.Category.Id).Name;
            result.Category.Number = context.Category.Find(result.Category.Id).Number;
            result.Week.Quarter = context.Week.Find(result.Week.Id).Quarter;
            result.Week.Year = context.Week.Find(result.Week.Id).Year;
            result.Week.Number = context.Week.Find(result.Week.Id).Number;

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeekEntry(int id, [FromBody] WeekEntryResource entryResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var entry = await context.WeekEntry.FindAsync(id); 
            mapper.Map<WeekEntryResource, WeekEntry>(entryResource, entry);
            entry.LastUpdated = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<WeekEntry, WeekEntryResource>(entry);
            result.Category.Name = context.Category.Find(result.Category.Id).Name;
            result.Category.Number = context.Category.Find(result.Category.Id).Number;
            result.Week.Quarter = context.Week.Find(result.Week.Id).Quarter;
            result.Week.Year = context.Week.Find(result.Week.Id).Year;
            result.Week.Number = context.Week.Find(result.Week.Id).Number;

            return Ok(result);
        }
    }
}