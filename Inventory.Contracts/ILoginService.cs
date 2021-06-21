using Inventory.Domain.DomainModels;
using System.Threading.Tasks;

namespace Inventory.Core
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
