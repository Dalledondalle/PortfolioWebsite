using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MelanWeb.Models
{
    public class AboutMeModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "sparetimeInterrests")]
        public string SparetimeInterrests { get; set; }

        [JsonProperty(PropertyName = "motivation")]
        public string Motivation { get; set; }

        [JsonProperty(PropertyName = "generelInformation")]
        public string GenerelInformation { get; set; }

        [JsonProperty(PropertyName = "backgroundInformation")]
        public string BackgroundInformation { get; set; }
    }
}
