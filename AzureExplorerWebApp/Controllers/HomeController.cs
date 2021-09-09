namespace AzureExplorerWebApp.Controllers
{
    using AzureExplorerWebApp.ApiModels;
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

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Marvel([Range(0, 100)]int limit = 20, int offset = 0)
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

            var hash = this.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Characters, timeStamp, publicKey, hash, limit, offset));

            var marvelCharacters = JsonSerializer.Deserialize<DataWrapperModel>(result);
            return View(marvelCharacters);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="publicKey"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        private string GetHash(string ts, string publicKey, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var generator = MD5.Create();
            byte[] bytesHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }
    }
}
