using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Core.Models;
using ACR2.Models;

namespace ACR2.Core
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetAllUsers();

         Task<User> GetUserById(int id);

        void AddUser(User user);

        void RemoveUser(User user);
    }
}