using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MelanWeb.Objects
{
    public class PortfolioObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("html_url")]
        public string GithubLink { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("open_issues")]
        public int OpenIssues { get; set; }
        [JsonProperty("issues_url")]
        public string IssueURL { get; set; }
        public string[] IssueURLs { get; set; }
        public IssueObject[] IssueObjects { get; set; }
        public string HashedModal { get { return "#" + Modal; } }
        public string Modal { get { return Name + "Modal"; } }
        public string Label { get { return Modal + "Label"; } }
    }
}
