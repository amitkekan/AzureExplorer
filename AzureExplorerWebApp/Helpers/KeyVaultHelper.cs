namespace AzureExplorerWebApp.Helpers
{
    using Azure.Core;
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public static class KeyVaultHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="secretName"></param>
        /// <returns></returns>
        public static string GetKeyVaultSecret(IConfiguration configuration, string secretName)
        {
            string result = null;

            var tenantId = configuration["AzureAd:TenantId"];
            var clientId = configuration["AzureAd:ClientId"];
            var clientSecret = configuration["AzureAd:ClientSecret"];
            var keyVaultUrl = configuration["KeyVault:Url"];

            ClientSecretCredential clientSecretCred = new ClientSecretCredential(tenantId, clientId, clientSecret);
            SecretClient secretClient = new SecretClient(new Uri(keyVaultUrl), clientSecretCred);
            result = secretClient.GetSecret(secretName).Value.Value;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="secretName"></param>
        /// <returns></returns>
        public static string GetManagedKeyVaultSecret(IConfiguration configuration, string secretName)
        {
            string result = null;

            var keyVaultUrl = configuration["KeyVault:Url"];

            TokenCredential credential = new DefaultAzureCredential();
            SecretClient secretClient = new SecretClient(new Uri(keyVaultUrl), credential);
            result = secretClient.GetSecret(secretName).Value.Value;

            return result;
        }
    }
}
