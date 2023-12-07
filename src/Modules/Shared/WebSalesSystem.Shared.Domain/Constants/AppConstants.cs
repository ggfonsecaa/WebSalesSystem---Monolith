namespace WebSalesSystem.Shared.Domain.Constants;
public static class AppConstants
{
    public static readonly string REQUESTID_HEADER = "X-RequestId";
    public static readonly string REQUESTID_KEY = "RequestId"; //Clave para el diccionario de datos

    public static readonly string TENANT_HEADER = "X-Tenant";
    public static readonly string TENANT_ROUTE = "tenant";
    public static readonly string TENANT_KEY = "TenantId"; //Clave para el diccionario de datos

    public static readonly string SUBTENANT_HEADER = "X-Subtenant";
    public static readonly string SUBTENANT_KEY = "SubtenantId"; //Clave para el diccionario de datos
}