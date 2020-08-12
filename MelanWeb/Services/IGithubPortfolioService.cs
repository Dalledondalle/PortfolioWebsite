using MelanWeb.Models;
using MelanWeb.Objects;
using System.Threading.Tasks;

namespace MelanWeb.Services
{
    public interface IGithubPortfolioService
    {
        Task<PortfolioModel> GetGithubRepos();
        IssueObject GetIssueObject(string href);
    }
}