using Azure;
using Azure.Data.Tables;
using Final_Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Retail.Services
{
    public class ProductService
    {
        private readonly TableClient _tableClient;

        public ProductService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);
            _tableClient.CreateIfNotExists();
        }

        public async Task<Product> GetProductAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _tableClient.GetEntityAsync<Product>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions like entity not found
                throw new Exception($"Product with PartitionKey: {partitionKey} and RowKey: {rowKey} not found.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string partitionKey)
        {
            try
            {
                return _tableClient.Query<Product>(p => p.PartitionKey == partitionKey).ToList();
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error retrieving products.", ex);
            }
        }

        public async Task AddOrUpdateProductAsync(Product product)
        {
            try
            {
                await _tableClient.UpsertEntityAsync(product);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error adding or updating product.", ex);
            }
        }

        public async Task DeleteProductAsync(string partitionKey, string rowKey)
        {
            try
            {
                await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception($"Error deleting product with PartitionKey: {partitionKey} and RowKey: {rowKey}.", ex);
            }
        }
    }
}
