using System.Collections;
using System.Collections.Generic;
using ACR2.Models.Resources;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ACR2.Models;
using ACR2.Core;

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

        public async Task<User> GetUserById(string id)
        {
            return await context.User.FindAsync(id);
        }

        public void RemoveUser(User user)
        {
            context.User.Remove(user);
        }
    }
}