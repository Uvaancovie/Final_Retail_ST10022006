using Azure;
using Azure.Data.Tables;
using Final_Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Retail.Services
{
    public class OrderService
    {
        private readonly TableClient _tableClient;

        public OrderService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);
            _tableClient.CreateIfNotExists();
        }

        public async Task<Order> GetOrderAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _tableClient.GetEntityAsync<Order>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions like entity not found
                throw new Exception($"Order with PartitionKey: {partitionKey} and RowKey: {rowKey} not found.", ex);
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(string partitionKey)
        {
            try
            {
                return _tableClient.Query<Order>(p => p.PartitionKey == partitionKey).ToList();
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error retrieving orders.", ex);
            }
        }

        public async Task AddOrUpdateOrderAsync(Order order)
        {
            try
            {
                await _tableClient.UpsertEntityAsync(order);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error adding or updating order.", ex);
            }
        }

        public async Task DeleteOrderAsync(string partitionKey, string rowKey)
        {
            try
            {
                await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception($"Error deleting order with PartitionKey: {partitionKey} and RowKey: {rowKey}.", ex);
            }
        }
    }
}
