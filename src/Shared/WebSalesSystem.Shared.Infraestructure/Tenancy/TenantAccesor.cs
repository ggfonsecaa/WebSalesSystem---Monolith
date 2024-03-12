namespace WebSalesSystem.Shared.Infraestructure.Tenancy;
public class TenantAccessor(IConfiguration configuration, IHttpContextAccessor contextAccessor, ITenantStorage tenantStore/*, ConsumeContext consumeContext*/) : ITenantAccessor
{
    private readonly IHttpContextAccessor _contextAccessor = contextAccessor;
    private readonly IConfiguration _configuration = configuration;
    private readonly ITenantStorage _tenantStore = tenantStore;

    public Tenant? Tenant { get; private set; }
    public SubTenant? SubTenant { get; private set; }


    public async Task GetTenantAsync()
    {
        Tenant = _contextAccessor.HttpContext?.GetTenant();

        if (Tenant is null)
        {
            //identifier ??= consumeContext.Headers.FirstOrDefault(x => x.Key == AppConstants.TENANT_HEADER).Value.ToString();
            Tenant = await _tenantStore.GetTenantAsync(default);
            _contextAccessor.HttpContext?.Items.Add(AppConstants.TENANT_KEY, Tenant);
        };
    }

    public async Task GetSubTenantAsync() 
    {
        SubTenant = _contextAccessor.HttpContext?.GetSubTenant();

        if (SubTenant is null)
        {
            //id ??= consumeContext.Headers.FirstOrDefault(x => x.Key == AppConstants.SUBTENANT_HEADER).Value.ToString()!.FromHashId();
            SubTenant = await _tenantStore.GetSubTenantAsync(default);
            _contextAccessor.HttpContext?.Items.Add(AppConstants.SUBTENANT_KEY, SubTenant);
        }
    }


    public string GetConnectionString(string context)
    {
        ConnectionStrings connectionStrings = new();
        _configuration.GetSection("DataConnections").Bind(connectionStrings);

        string connectionContext = connectionStrings.GetType().GetProperty(context)!.GetValue(connectionStrings)!.ToString()!;

        if (Tenant!.Configuration.StorageType != StorageType.Shared) 
        {
            return $"{connectionContext}".Replace("{dbName}", $@"{Tenant!.Configuration.StorageName}");
        }
        
        return connectionContext;
    }
}