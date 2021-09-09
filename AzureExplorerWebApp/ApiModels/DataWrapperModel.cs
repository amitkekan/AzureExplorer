namespace AzureExplorerWebApp.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class DataWrapperModel
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("attributionText")]
        public string AttributionText { get; set; }

        [JsonPropertyName("attributionHTML")]
        public string AttributionHTML { get; set; }

        [JsonPropertyName("etag")]
        public string ETag { get; set; }

        [JsonPropertyName("data")]
        public DataContainerModel Data { get; set; }
    }
}
