namespace AzureExplorerWebApp.ApiModels.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class CharacterModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

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

        public string DetailUrl
        {
            get
            {
                var url =  this.Urls.Where(i => i.Type == "detail").FirstOrDefault();

                return url != null ? url.Url : string.Empty;
            }
        }

        public string WikiUrl
        {
            get
            {
                var url = this.Urls.Where(i => i.Type == "wiki").FirstOrDefault();

                return url != null ? url.Url : string.Empty;
            }
        }

        public string ComicUrl
        {
            get
            {
                var url = this.Urls.Where(i => i.Type == "comiclink").FirstOrDefault();

                return url != null ? url.Url : string.Empty;
            }
        }
    }
}
