using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Models.Resources;
using ACR2.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACR2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ACRDbContext context;
        private readonly IMapper mapper;
        public CategoryController(ACRDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("/api/categories")]
        public async Task<IEnumerable<CategoryResource>> GetCategories()
        {
            var categories = await context.Category.ToListAsync();

            return mapper.Map<List<Category>, List<CategoryResource>>(categories);
        }
    }
}