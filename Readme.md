# Multi Tenant Configuration Demo

## How To Run

1. Put config files named `TenantConfigs__Tree__Tenant<TenantNumberHere>` into `tenant-configs` directory.
2. File contents look like
```
{
	"Name": "Tenant One",
	"TTL": 300
}
```
3. Run the app and hit `api/tenantconfig/{tenantId}` url