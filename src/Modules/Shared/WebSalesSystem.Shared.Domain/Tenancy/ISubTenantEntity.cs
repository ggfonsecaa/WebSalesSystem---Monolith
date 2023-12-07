namespace WebSalesSystem.Shared.Domain.Tenancy;
public interface ISubTenantEntity : ITenantEntity
{
    public int SubTenantId { get; set; }
}