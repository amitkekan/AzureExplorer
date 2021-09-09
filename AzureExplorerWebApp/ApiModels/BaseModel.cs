namespace AzureExplorerWebApp.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class BaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
