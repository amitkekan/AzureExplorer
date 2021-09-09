namespace AzureExplorerWebApp.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class CharacterModel : BaseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("modified")]
        public string Modified { get; set; }

        [JsonPropertyName("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonPropertyName("urls")]
        public List<UrlModel> Urls { get; set; }

        [JsonPropertyName("thumbnail")]
        public ImageModel Thumbnail { get; set; }
    }
}
