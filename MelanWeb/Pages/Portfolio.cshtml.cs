using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelanWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MelanWeb.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly IGithubPortfolioService Github;
        public PortfolioModel(IGithubPortfolioService github)
        {
            Github = github;
        }
        public string PageTitle { get; set; } = "Portfolio";
        public void OnGet()
        {
            if(GithubPortfolio.LastRefreshed.AddDays(1) < DateTime.Now) GithubPortfolio.Content = Github.GetGithubRepos();
        }
    }
}