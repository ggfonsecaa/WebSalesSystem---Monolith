namespace WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
public class DbProvider(int id, string name) : Enumeration(id, name)
{
    public static readonly DbProvider InMemory = new(1, nameof(InMemory));
    public static readonly DbProvider SqlServer = new(2, nameof(SqlServer));
    public static readonly DbProvider Oracle = new(3, nameof(Oracle));
    public static readonly DbProvider PostgreSql = new(4, nameof(PostgreSql));
}