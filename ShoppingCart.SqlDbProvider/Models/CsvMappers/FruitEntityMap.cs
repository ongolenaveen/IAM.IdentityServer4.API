﻿using CsvHelper.Configuration;
using Shopping.SqlDbProvider.Models.Entities;

namespace Shopping.SqlDbProvider.Models.CsvMappers
{
    /// <summary>
    /// CSV to Fruit Entity Map
    /// </summary>
    public class FruitEntityMap: ClassMap<FruitEntity>
    {
        public FruitEntityMap()
        {
            Map(m => m.Name).Name("fruit");
            Map(m => m.Price).Name("price");
            Map(m => m.QuantityInStock).Name("quantity_in_stock");
            Map(m => m.UpdatedDate).Name("updated_date");
        }
    }
}
