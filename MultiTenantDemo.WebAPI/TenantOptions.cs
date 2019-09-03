using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantDemo.WebAPI
{
    public class TenantOptions
    {
        public string Name { get; set; }
        public int TTL { get; set; }
    }
}
