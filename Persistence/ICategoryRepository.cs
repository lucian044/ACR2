using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Models;

namespace ACR2.Persistence
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> GetAllCategories();

         Task<Category> GetCategoryById(int id);
    }
}