using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MultiTenantDemo.WebAPI.Controllers
{
    [ApiController]
    public class TenantConfigController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public TenantConfigController(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpGet("api/tenantconfig/{tenantId}")]
        public ActionResult<string> Get(int tenantId)
        {
            var value = configuration.GetValue<string>($"TenantConfigs:Tree:Tenant{tenantId}");

            return value ?? $"can't get config value for tenant '{tenantId}'";
        }
    }
}