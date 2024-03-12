namespace WebSalesSystem.Shared.Domain.ConfigurationModels;
public class ConnectionStrings
{
    public string? AppDbContext { get; set; }
    public string? AdminDbContext { get; set; }
    public string? AuthDbContext { get; set; }
}