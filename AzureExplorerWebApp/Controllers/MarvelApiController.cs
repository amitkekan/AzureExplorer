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
    using System.Text.Json;
    using AzureExplorerWebApp.ApiModels;

    [Route("api/[controller]")]
    [ApiController]
    public class MarvelApiController : ControllerBase
    {
        private readonly ILogger<MarvelApiController> _logger;

        private readonly IConfiguration _configuration;


        public MarvelApiController(ILogger<MarvelApiController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }

        [Route(ApiConstants.Characters)]
        [HttpGet]
        public async Task<IActionResult> Characters(int limit = 20, int offset = 0)
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

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Characters, timeStamp, publicKey, hash, limit, offset));
            return Ok(result);
        }

        [Route(ApiConstants.Comics)]
        [HttpGet]
        public async Task<IActionResult> Comics(int limit = 20, int offset = 0)
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

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Comics, timeStamp, publicKey, hash, limit, offset));
            return Ok(result);
        }

        [Route(ApiConstants.Creators)]
        [HttpGet]
        public async Task<IActionResult> Creators(int limit = 20, int offset = 0)
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

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Creators, timeStamp, publicKey, hash, limit, offset));
            return Ok(result);
        }

        [Route(ApiConstants.Events)]
        [HttpGet]
        public async Task<IActionResult> Events(int limit = 20, int offset = 0)
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

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Events, timeStamp, publicKey, hash, limit, offset));
            return Ok(result);
        }

        [Route(ApiConstants.Series)]
        [HttpGet]
        public async Task<IActionResult> Series(int limit = 20, int offset = 0)
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

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Series, timeStamp, publicKey, hash, limit, offset));
            return Ok(result);
        }

        [Route(ApiConstants.Stories)]
        [HttpGet]
        public async Task<IActionResult> Stories(int limit = 20, int offset = 0)
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

            var publicKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Public-Key");
            var privateKey = KeyVaultHelper.GetManagedKeyVaultSecret(_configuration, "Marvel-Private-Key");

            var timeStamp = DateTime.Now.Ticks.ToString();

            var hash = HttpHelper.GetHash(timeStamp, publicKey, privateKey);

            var result = await HttpHelper.GetResult(string.Format(ApiConstants.ApiUrlFormat, ApiConstants.Stories, timeStamp, publicKey, hash, limit, offset));
            return Ok(result);
        }
    }
}
