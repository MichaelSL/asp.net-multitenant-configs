using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MultiTenantDemo.WebAPI.Controllers
{
    [ApiController]
    public class TenantConfigController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<TenantConfigController> logger;

        public TenantConfigController(IConfiguration configuration, ILogger<TenantConfigController> logger)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.logger = logger;
        }

        [HttpGet("api/tenantconfig/{tenantId}")]
        public ActionResult<TenantOptions> Get(int tenantId)
        {
            TenantOptions value = null;
            var section = configuration.GetSection($"TenantConfigs:Tree:Tenant{tenantId}");
            if (section != null)
            {
                value = section.Get<TenantOptions>();
                if (value == null)
                {
                    logger.LogInformation("Trying to deserialize from string");
                    try
                    {
                        value = JsonConvert.DeserializeObject<TenantOptions>(section.Value);
                    }
                    catch (Exception deserilizationException)
                    {
                        logger?.LogWarning(deserilizationException, "Can't deserialize tenant config");
                    }
                }
            }

            if (value == null)
                return NotFound();
            else
                return value;
        }
    }
}