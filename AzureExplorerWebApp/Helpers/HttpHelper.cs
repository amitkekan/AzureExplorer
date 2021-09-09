namespace AzureExplorerWebApp.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string GetHash(string ts, string publicKey, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var generator = MD5.Create();
            byte[] bytesHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }
    }
}
