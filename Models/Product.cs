using Azure;
using Azure.Data.Tables;
using System;

namespace Final_Retail.Models // Add this namespace declaration
{
    public class Product : ITableEntity
    {
        // PartitionKey will group similar entities together, like all products
        public string PartitionKey { get; set; }

        // RowKey is a unique identifier for the entity within the partition
        public string RowKey { get; set; }

        // Timestamp is automatically managed by Azure
        public DateTimeOffset? Timestamp { get; set; }

        // ETag is used for concurrency checks
        public ETag ETag { get; set; }

        // Custom properties for the Product entity
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        // Constructor to initialize default values
        public Product()
        {
            // You can set PartitionKey based on some logic, like Category, or keep it fixed
            PartitionKey = "Products";
            RowKey = Guid.NewGuid().ToString(); // Unique ID for each product
        }
    }
}
