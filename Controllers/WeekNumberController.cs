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
    public class WeekNumberController : Controller
    {
        private readonly ACRDbContext context;
        private readonly IMapper mapper;
        public WeekNumberController(ACRDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/weeknumbers")]
        public async Task<IEnumerable<WeekNumberResource>> GetWeekNumbers()
        {
            var numbers = await context.WeekNumber.ToListAsync();

            return mapper.Map<List<WeekNumber>, List<WeekNumberResource>>(numbers);
        }
    }
}