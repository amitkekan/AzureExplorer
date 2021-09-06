namespace AzureExplorerWebApp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class HttpHelper
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetResult(string httpUrl)
        {
            try
            {                
                string responseBody = await client.GetStringAsync(httpUrl);

                // stream responseJson = await client.GetStreamAsync(httpUrl);
                // var responseObject = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }
    }
}
