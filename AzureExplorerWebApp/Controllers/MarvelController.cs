namespace AzureExplorerWebApp.Controllers
{
    using AzureExplorerWebApp.Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.Text;

    [Route("api/[controller]")]
    [ApiController]
    public class MarvelController : ControllerBase
    {
        private readonly ILogger<MarvelController> _logger;

        private readonly IConfiguration _configuration;

        public MarvelController(ILogger<MarvelController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }

        [Route("comics")]
        [HttpGet]
        public async Task<IActionResult> Comics()
        {
            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = this.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format("http://gateway.marvel.com/v1/public/comics?ts={0}&apikey={1}&hash={2}", timeStamp, publicKey, hash));
            return Ok(result);
        }

        [Route("characters")]
        [HttpGet]
        public async Task<IActionResult> Characters()
        {
            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = this.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format("http://gateway.marvel.com/v1/public/characters?ts={0}&apikey={1}&hash={2}", timeStamp, publicKey, hash));
            return Ok(result);
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
