namespace AzureExplorerWebApp.ApiModels.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class ImageModel
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        public string Url
        {
            get
            {
                return this.Path + "." + this.Extension;
            }
        }
    }
}
