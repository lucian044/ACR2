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
    public class WeekController: Controller
    {
        private readonly ACRDbContext context;
        private readonly IMapper mapper;
        public WeekController(ACRDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/weeks")]
        public async Task<IEnumerable<WeekResource>> GetWeeks()
        {
            var weeks = await context.Week.Include(w => w.Entries).ToListAsync();

            return mapper.Map<List<Week>, List<WeekResource>>(weeks);
        }
    }
}