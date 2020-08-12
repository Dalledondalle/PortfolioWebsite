using MelanWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MelanWeb.Services
{
    public interface ICosmosDBService
    {
        Task<IEnumerable<AboutMeModel>> GetItemsAsync(string query);
        Task<AboutMeModel> GetAboutMeAsync();
        Task AddAboutMeAsync(AboutMeModel aboutMe);
        Task UpdateItemAsync(string id, AboutMeModel aboutMe);
        Task DeleteAboutMeAsync(string id);
        Task<ExperiencesModel> GetExperiencesAsync();

    }
}