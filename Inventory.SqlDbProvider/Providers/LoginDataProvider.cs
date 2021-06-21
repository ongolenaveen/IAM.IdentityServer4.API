using Inventory.Domain.DomainModels;
using Inventory.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Inventory.SqlDbProvider.Providers
{
    public class LoginDataProvider : ILoginDataProvider
    {
        public Task<LoginResponse> Login(LoginRequest request)
        {
            if (request.UserName.Equals("naveen.papisetty", StringComparison.InvariantCultureIgnoreCase))
                return Task.FromResult(new LoginResponse { FirstName = "Naveen", LastName = "Papisetty" });
            else
                return null;
        }
    }
}
