<<<<<<< HEAD
﻿using Azure;
using Azure.Data.Tables;
using System;

namespace Final_Retail.Models
{
    public class CustomerProfile : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Custom properties for the CustomerProfile entity
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Constructor to initialize default values
        public CustomerProfile()
        {
            // You can set PartitionKey based on some logic, like Category, or keep it fixed
            PartitionKey = "CustomerProfiles";
            RowKey = Guid.NewGuid().ToString(); // Unique ID for each customer profile
        }
    }
}
=======
﻿using Azure;
using Azure.Data.Tables;
using System;

namespace Final_Retail.Models
{
    public class CustomerProfile : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Custom properties for the CustomerProfile entity
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Constructor to initialize default values
        public CustomerProfile()
        {
            // You can set PartitionKey based on some logic, like Category, or keep it fixed
            PartitionKey = "CustomerProfiles";
            RowKey = Guid.NewGuid().ToString(); // Unique ID for each customer profile
        }
    }
}
>>>>>>> 1c0e17787d4e6a4bebdd1ef0692a2fa41b7378a6
