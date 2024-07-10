namespace WebSalesSystem.Admin.API.Contracts;
public class RegisterSubTenantRequest
{
    public int IdentificationType { get; set; }
    public string? IdentificationNumber { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
}