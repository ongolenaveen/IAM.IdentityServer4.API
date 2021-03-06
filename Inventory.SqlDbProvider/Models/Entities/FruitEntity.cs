using System;

namespace Inventory.SqlDbProvider.Models.Entities
{
    public partial class FruitEntity
    {
        /// <summary>
        /// Identification Number
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity In Stock
        /// </summary>
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Updated Date
        /// </summary>
        public DateTime UpdatedDate{get;set;}
    }
}
