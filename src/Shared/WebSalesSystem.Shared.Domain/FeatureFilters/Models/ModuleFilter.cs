namespace WebSalesSystem.Shared.Domain.FeatureFilters.Models;
public class ModuleFilter
{
    public IEnumerable<string> Modules { get; set; } = new List<string>();
}