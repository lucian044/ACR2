using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;

namespace ACR2.Persistence
{
    public class CategoryRepository : ICategoryRepository 
    {
        private readonly ACRDbContext context;
        public CategoryRepository(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await context.Category.FindAsync(id);
        }
    }
}