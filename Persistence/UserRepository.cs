using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;
using System.Linq;

namespace ACR2.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ACRDbContext context;
        public UserRepository(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.User.ToListAsync();
        }

        public void AddUser(User user)
        {
            context.User.Add(user);
        }

        public IQueryable<User> GetUserById(string id)
        {
            return context.User.Where(u => u.Auth0Id == id);
        }

        public void RemoveUser(User user)
        {
            context.User.Remove(user);
        }
    }
}