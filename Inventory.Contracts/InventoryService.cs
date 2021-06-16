using Inventory.Domain.DomainModels;
using Inventory.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Core
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryDataProvider _inventoryDataProvider;
        public InventoryService(IInventoryDataProvider inventoryDataProvider)
        {
            _inventoryDataProvider = inventoryDataProvider;
        }
        public async Task<IEnumerable<Fruit>> Retrieve()
        {
            return await _inventoryDataProvider.Retrieve();
        }

        public async Task Upload(InventoryFile inventoryFile)
        {
            await _inventoryDataProvider.Upload(inventoryFile);
        }
    }
}
