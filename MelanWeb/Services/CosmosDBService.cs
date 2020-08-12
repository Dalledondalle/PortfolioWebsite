using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using MelanWeb.Models;

namespace MelanWeb.Services
{
    public class CosmosDBService : ICosmosDBService
    {
        private Container _container;

        public CosmosDBService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddAboutMeAsync(AboutMeModel aboutMe)
        {
            await this._container.CreateItemAsync<AboutMeModel>(aboutMe, new PartitionKey(aboutMe.Id));
        }

        public async Task DeleteAboutMeAsync(string id)
        {
            await this._container.DeleteItemAsync<AboutMeModel>(id, new PartitionKey(id));
        }

        public async Task<AboutMeModel> GetAboutMeAsync()
        {
            try
            {
                ItemResponse<AboutMeModel> response = await this._container.ReadItemAsync<AboutMeModel>("AboutMe", new PartitionKey("AboutMe"));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<ExperiencesModel> GetExperiencesAsync()
        {
            try
            {
                ItemResponse<ExperiencesModel> response = await this._container.ReadItemAsync<ExperiencesModel>("Experiences", new PartitionKey("Experiences"));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<AboutMeModel>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<AboutMeModel>(new QueryDefinition(queryString));
            List<AboutMeModel> results = new List<AboutMeModel>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, AboutMeModel aboutMe)
        {
            await this._container.UpsertItemAsync<AboutMeModel>(aboutMe, new PartitionKey(id));
        }
    }
}
