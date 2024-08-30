using Azure;
using Azure.Data.Tables;
using Final_Retail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Retail.Services
{
    public class CustomerProfileService
    {
        private readonly TableClient _tableClient;

        public CustomerProfileService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);
            _tableClient.CreateIfNotExists();
        }

        public async Task<CustomerProfile> GetCustomerProfileAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _tableClient.GetEntityAsync<CustomerProfile>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions like entity not found
                throw new Exception($"CustomerProfile with PartitionKey: {partitionKey} and RowKey: {rowKey} not found.", ex);
            }
        }

        public async Task<IEnumerable<CustomerProfile>> GetCustomerProfilesAsync(string partitionKey)
        {
            try
            {
                return _tableClient.Query<CustomerProfile>(p => p.PartitionKey == partitionKey).ToList();
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error retrieving customer profiles.", ex);
            }
        }

        public async Task AddOrUpdateCustomerProfileAsync(CustomerProfile customerProfile)
        {
            try
            {
                await _tableClient.UpsertEntityAsync(customerProfile);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception("Error adding or updating customer profile.", ex);
            }
        }

        public async Task DeleteCustomerProfileAsync(string partitionKey, string rowKey)
        {
            try
            {
                await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
            }
            catch (RequestFailedException ex)
            {
                // Handle exceptions
                throw new Exception($"Error deleting customer profile with PartitionKey: {partitionKey} and RowKey: {rowKey}.", ex);
            }
        }
    }
}
