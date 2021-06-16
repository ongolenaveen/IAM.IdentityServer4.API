using Inventory.Domain.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core
{
    public interface IInventoryService
    {
        Task<IEnumerable<Fruit>> Retrieve();


        Task Upload(InventoryFile vehicle);
    }
}
