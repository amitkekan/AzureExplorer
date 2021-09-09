namespace AzureExplorerWebApp.Controllers
{
    using AzureExplorerWebApp.ApiModels.Characters;
    using AzureExplorerWebApp.Helpers;
    using AzureExplorerWebApp.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class MarvelController : Controller
    {
        private readonly ILogger<MarvelController> _logger;

        private readonly IConfiguration _configuration;

        public MarvelController(ILogger<MarvelController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration; 
        }

        public async Task<IActionResult> Characters([Range(0, 100)] int limit = 20, int offset = 0, string name = null)
        {
            // Validation
            if (limit <= 0 || limit > 100)
            {
                limit = 20;
            }

            if (offset < 0)
            {
                offset = 0;
            }

            //var apiResponse = await HttpHelper.GetResult("https://localhost:44368/api/marvel/characters");

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var requestUri = string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Characters, timeStamp, publicKey, hash, limit, offset);
            if (!string.IsNullOrWhiteSpace(name))
            {
                requestUri += ApiConstants.NameStartsWithFilter + name;
            }

            var result = await HttpHelper.GetResult(requestUri);

            var marvelCharacters = JsonSerializer.Deserialize<DataWrapperModel>(result);
            return View(marvelCharacters);
        }
    }
}
