using MelanWeb.Models;
using MelanWeb.Objects;
using System.Threading.Tasks;

namespace MelanWeb.Services
{
    public interface IGithubPortfolioService
    {
        PortfolioModel GetGithubRepos();
        IssueObject GetIssueObject(string href);
    }
}