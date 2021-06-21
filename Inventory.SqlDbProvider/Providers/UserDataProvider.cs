using Inventory.Domain.DomainModels;
using Inventory.Domain.Interfaces;
using System.Threading.Tasks;

namespace Inventory.SqlDbProvider.Providers
{
    public class UserDataProvider : IUserDataProvider
    {
        public Task<UserDetails> GetUser(string userName)
        {
            var user = new UserDetails
            {
                UserName = userName,
                FirstName = "Naveen",
                LastName = "Papisetty",
                SubjectId = "3",
                Address = new Address
                {
                    Line1 = "106",
                    Line2 = "Frimley Road",
                    Line3 = "Camberley",
                    Line4 = "Surrey",
                    PostCode = "GU15 3EG"
                }
            };
            return Task.FromResult(user);
        }
    }
}
