using Inventory.Domain.DomainModels;
using System.Threading.Tasks;

namespace Inventory.Domain.Interfaces
{
    public interface IUserDataProvider
    {
        Task<UserDetails> GetUser(string userName);
    }
}
