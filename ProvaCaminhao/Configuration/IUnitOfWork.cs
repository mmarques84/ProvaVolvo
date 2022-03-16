using System.Threading.Tasks;

namespace ProvaCaminhao.Configuration
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}