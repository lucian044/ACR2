using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Core;
using ACR2.Core.Models.Resources;
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
        private readonly IMapper mapper;
        private readonly IWeekEntryRepository entryRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly IWeekRepository weekRepo;
        private readonly IUnitOfWork uw;

        public WeekEntryController(
            IMapper mapper, 
            IWeekEntryRepository entryRepo,
            ICategoryRepository categoryRepo,
            IWeekRepository weekRepo,
            IUnitOfWork uw
        )
        {
            this.entryRepo = entryRepo;
            this.categoryRepo = categoryRepo;
            this.weekRepo = weekRepo;
            this.uw = uw;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<WeekEntryResource>> GetWeekEntries()
        {
            var entries = await entryRepo.GetAllEntries();

            var result = mapper.Map<IEnumerable<WeekEntry>, IEnumerable<WeekEntryResource>>(entries);

            return result;

        }

        [HttpPost("post")]
        public async Task<IActionResult> CreateWeekEntry([FromBody] SaveWeekEntryResource entryResource)
        {
            throw new Exception();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await categoryRepo.GetCategoryById(entryResource.CategoryId);
            var week = await weekRepo.GetWeekById(entryResource.WeekId);
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

            var entry = mapper.Map<SaveWeekEntryResource, WeekEntry>(entryResource);
            entry.LastUpdated = DateTime.Now;

            entryRepo.AddEntry(entry);
            await uw.CompleteAsync();

            var result = mapper.Map<WeekEntry, WeekEntryResource>(entry);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeekEntry(int id, [FromBody] WeekEntryResource entryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entry = await entryRepo.GetEntryById(id);

            if (entry == null)
                return NotFound();

            mapper.Map<WeekEntryResource, WeekEntry>(entryResource);
            entry.LastUpdated = DateTime.Now;

            await uw.CompleteAsync();

            var result = mapper.Map<WeekEntry, WeekEntryResource>(entry);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeekEntry(int id)
        {
            var entry = await entryRepo.GetEntryById(id, loadFull: false);

            if (entry == null)
                return NotFound();

            entryRepo.RemoveEntry(entry);
            await uw.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeekEntry(int id)
        {
            var entry = await entryRepo.GetEntryById(id);

            if (entry == null)
                return NotFound();

            var entryResource = mapper.Map<WeekEntry, WeekEntryResource>(entry);

            return Ok(entryResource);
        }
    }
}