using System.Threading.Tasks;

namespace ACR2.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}