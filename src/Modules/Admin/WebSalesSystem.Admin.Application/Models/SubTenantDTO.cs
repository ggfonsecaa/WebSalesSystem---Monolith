namespace WebSalesSystem.Admin.Application.Models;
public class SubTenantDTO
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public TenantModel? Tenant { get; set; }
}

public class TenantModel 
{ 
    public string? TenantId { get; set; }    
    public string? Name { get; set; }
}