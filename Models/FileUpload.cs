<<<<<<< HEAD
﻿using Azure.Data.Tables;
using Azure;

namespace Final_Retail.Models
{
    public class FileUpload : ITableEntity
    {
        // PartitionKey groups similar entities together, such as all file uploads
        public string PartitionKey { get; set; }

        // RowKey is a unique identifier for the entity within the partition
        public string RowKey { get; set; }

        // Timestamp is automatically managed by Azure Table Storage
        public DateTimeOffset? Timestamp { get; set; }

        // ETag is used for concurrency checks
        public ETag ETag { get; set; }

        // Custom properties specific to the FileUpload entity
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ContentType { get; set; }
        public string FileType { get; set; }  // New property to represent the type of the file (e.g., Document, Image)

        // Constructor to initialize default values
        public FileUpload()
        {
            PartitionKey = "FileUploads";
            RowKey = Guid.NewGuid().ToString(); // Unique ID for each file upload
        }
    }
}
=======
﻿using Azure.Data.Tables;
using Azure;

namespace Final_Retail.Models
{
    public class FileUpload : ITableEntity
    {
        // PartitionKey groups similar entities together, such as all file uploads
        public string PartitionKey { get; set; }

        // RowKey is a unique identifier for the entity within the partition
        public string RowKey { get; set; }

        // Timestamp is automatically managed by Azure Table Storage
        public DateTimeOffset? Timestamp { get; set; }

        // ETag is used for concurrency checks
        public ETag ETag { get; set; }

        // Custom properties specific to the FileUpload entity
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string ContentType { get; set; }
        public string FileType { get; set; }  // New property to represent the type of the file (e.g., Document, Image)

        // Constructor to initialize default values
        public FileUpload()
        {
            PartitionKey = "FileUploads";
            RowKey = Guid.NewGuid().ToString(); // Unique ID for each file upload
        }
    }
}
>>>>>>> 1c0e17787d4e6a4bebdd1ef0692a2fa41b7378a6
