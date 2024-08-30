using Azure;
using Azure.Data.Tables;
using Final_Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Retail.Services
{
    public class FileUploadService
    {
        private readonly TableClient _tableClient;

        public FileUploadService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);
            _tableClient.CreateIfNotExists();
        }

        public async Task<FileUpload> GetFileUploadAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _tableClient.GetEntityAsync<FileUpload>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions like entity not found
                throw new Exception($"FileUpload with PartitionKey: {partitionKey} and RowKey: {rowKey} not found.", ex);
            }
        }

        public async Task<IEnumerable<FileUpload>> GetFileUploadsAsync(string partitionKey)
        {
            try
            {
                return _tableClient.Query<FileUpload>(p => p.PartitionKey == partitionKey).ToList();
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error retrieving file uploads.", ex);
            }
        }

        public async Task AddOrUpdateFileUploadAsync(FileUpload fileUpload)
        {
            try
            {
                await _tableClient.UpsertEntityAsync(fileUpload);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error adding or updating file upload.", ex);
            }
        }

        public async Task DeleteFileUploadAsync(string partitionKey, string rowKey)
        {
            try
            {
                await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception($"Error deleting file upload with PartitionKey: {partitionKey} and RowKey: {rowKey}.", ex);
            }
        }
    }
}
