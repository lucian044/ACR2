using System.Threading.Tasks;
using ACR2.Core;

namespace ACR2.Persistence
{
     public class UnitOfWork : IUnitOfWork
    {
        private readonly ACRDbContext context;
        public UnitOfWork(ACRDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}