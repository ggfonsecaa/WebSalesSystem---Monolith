namespace WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
public class DbProviderConverter : ValueConverter<DbProvider, int>
{
    public DbProviderConverter() : base(x => x.Id, x => Enumeration.FromId<DbProvider>(x)!) { }
}