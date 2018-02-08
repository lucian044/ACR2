using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Core;
using ACR2.Core.Models;
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
        public async Task<QueryResultResource<WeekEntryResource>> GetWeekEntries(WeekEntryQueryResource filterResource)
        {
            var filter = mapper.Map<WeekEntryQueryResource, WeekEntryQuery>(filterResource);
            var queryResult = await entryRepo.GetAllEntries(filter);

            return mapper.Map<QueryResult<WeekEntry>, QueryResultResource<WeekEntryResource>>(queryResult);

        }

        [HttpPost("post")]
        public async Task<IActionResult> CreateWeekEntry([FromBody] SaveWeekEntryResource[] entryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                var result = new List<WeekEntryResource>();
            for (var i = 1; i < 12; i++)
            {
                foreach (var e in entryResource) {
                    e.WeekId = i;
                }
                foreach (var e in entryResource)
                {
                    var category = await categoryRepo.GetCategoryById(e.CategoryId);

                    var week = await weekRepo.GetWeekById(e.WeekId);
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

                    var entry = mapper.Map<SaveWeekEntryResource, WeekEntry>(e);
                    entry.LastUpdated = DateTime.Now;

                    entryRepo.AddEntry(entry);
                    await uw.CompleteAsync();

                    var res = mapper.Map<WeekEntry, WeekEntryResource>(entry);
                    result.Add(res);
                }
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeekEntry(int id, [FromBody] SaveWeekEntryResource entryResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entry = await entryRepo.GetEntryById(id);

            if (entry == null)
                return NotFound();

            mapper.Map<SaveWeekEntryResource, WeekEntry>(entryResource, entry);
            entry.LastUpdated = DateTime.Now;
            entry.Category = await categoryRepo.GetCategoryById(entry.CategoryId);
            entry.Week = await weekRepo.GetWeekById(entry.WeekId);

            await uw.CompleteAsync();

            entry = await entryRepo.GetEntryById(entry.Id);
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