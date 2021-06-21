using Inventory.Domain.DomainModels;
using System.Threading.Tasks;

namespace Inventory.Domain.Interfaces
{
    public interface ILoginDataProvider
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
