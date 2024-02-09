namespace WebSalesSystem.Shared.Domain.SeedWork;
public interface IAuditableEntity
{
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
}