using System.Threading.Tasks;

namespace ACR2.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}