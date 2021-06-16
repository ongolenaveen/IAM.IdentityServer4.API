using Inventory.Core;
using Inventory.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Inventory.Api
{
    /// <summary>
    /// Groceries Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public  class GroceriesController : ControllerBase {

        private readonly IInventoryService _inventoryService;

        /// <summary>
        /// Constructor for Groceries Controller
        /// </summary>
        /// <param name="inventoryDataProvider">Inventory Data Provider</param>
        public GroceriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        /// <summary>
        /// Upload Inventory File into Database
        /// </summary>
        /// <param name="inventoryFile">Inventory File </param>
        /// <returns>Action Result</returns>
        [HttpPost("Upload")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Upload(InventoryFile inventoryFile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _inventoryService.Upload(inventoryFile);
            return Ok();
        }

        /// <summary>
        /// Retrieve Groceries from Inventory
        /// </summary>
        /// <returns>Groceries from Inventory</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Fruit>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<Fruit>>> Get()
        {
            var response = await _inventoryService.Retrieve();
            return Ok(response);
        }
    }
}
