using MelanWeb.Models;
using MelanWeb.Objects;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MelanWeb.Services
{
    public class GithubPortfolioService : IGithubPortfolioService
    {
        private string Username;
        public GithubPortfolioService(string username = "DalleDonDalle")
        {
            Username = username;
        }
        public async Task<PortfolioModel> GetGithubRepos()
        {
            var client = new RestClient($"https://api.github.com/users/{Username}/repos");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            try
            {
                Debug.WriteLine(response.Content);
                PortfolioModel p = new PortfolioModel();
                p.PortfolioObjects = JsonConvert.DeserializeObject<PortfolioObject[]>(response.Content);
                
                foreach (var t in p.PortfolioObjects)
                {
                    t.IssueURLs = new string[t.OpenIssues];
                    t.IssueObjects = new IssueObject[t.OpenIssues];
                    t.IssueURL = t.IssueURL.Remove(t.IssueURL.Length - 9, 9);
                    t.IssueURL = t.IssueURL + '/';
                    if (t.OpenIssues > 0)
                    {
                        for (int i = 0; i < t.OpenIssues; i++)
                        {
                            t.IssueURLs[i] = t.IssueURL + (i + 1).ToString();
                            t.IssueObjects[i] = GetIssueObject(t.IssueURLs[i]);
                        }
                    }
                }
                return p;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IssueObject GetIssueObject(string href)
        {
            var client = new RestClient(href);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            try
            {
                return JsonConvert.DeserializeObject<IssueObject>(response.Content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}


