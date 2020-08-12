using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MelanWeb.Objects
{
    public class IssueObject
    {
        [JsonProperty("body")]
        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
                MakeImgURL(value);
            }
        }
        private string body;
        [JsonProperty("title")]
        public string Title { get; set; }
        public string ImgURL { get; set; }

        private void MakeImgURL(string s)
        {
            string t = s.Substring(s.IndexOf('(') + 1);
            t = t.Remove(t.Length - 3, 3);
            ImgURL = t;
        }
    }
}
