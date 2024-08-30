using Azure;
using Azure.Data.Tables;
using System;

namespace Final_Retail.Models // Add this namespace declaration
{
    public class Order : ITableEntity
    {
        // PartitionKey groups similar entities together, such as all orders
        public string PartitionKey { get; set; }

        // RowKey is a unique identifier for the entity within the partition
        public string RowKey { get; set; }

        // Timestamp is automatically managed by Azure Table Storage
        public DateTimeOffset? Timestamp { get; set; }

        // ETag is used for concurrency checks
        public ETag ETag { get; set; }

        // Custom properties specific to the Order entity
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        // Constructor to initialize default values
        public Order()
        {
            PartitionKey = "Orders";
            RowKey = Guid.NewGuid().ToString(); // Unique ID for each order
        }
    }
}