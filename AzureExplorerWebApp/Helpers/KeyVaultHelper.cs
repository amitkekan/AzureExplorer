namespace AzureExplorerWebApp.Helpers
{
    using Azure.Core;
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using Microsoft.Extensions.Configuration;
    using System;

    /// <summary>
    /// The Keyvault Helper class
    /// </summary>
    public static class KeyVaultHelper
    {
        /// <summary>
        /// Gets the key vault secret value by either managed identity or client secret based on isDebug flag.
        /// </summary>
        /// <param name="configuration">The configuration object</param>
        /// <param name="secretName">The secret name</param>
        /// <returns>The secret value as string</returns>
        public static string GetKeyVaultSecret(IConfiguration configuration, string secretName)
        {
            string result = null;

            var tenantId = configuration["AzureAd:TenantId"];
            var clientId = configuration["AzureAd:ClientId"];
            var clientSecret = configuration["AzureAd:ClientSecret"];
            var keyVaultUrl = configuration["KeyVault:Url"];
            bool isDebug = false;
            Boolean.TryParse(configuration["IsDebug"], out isDebug);

            TokenCredential credential = null;

            if (isDebug)
            {
                // Make sure to have Registered App in ADD added to the "Access Policy" of the KeyVault
                credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            }
            else
            {
                // Make sure to have Identity Generated for App Service, then this Identity added to the "Access Policy" of the KeyVault
                credential = new DefaultAzureCredential();
            }

            SecretClient secretClient = new SecretClient(new Uri(keyVaultUrl), credential);
            result = secretClient.GetSecret(secretName).Value.Value;

            return result;
        }
    }
}
