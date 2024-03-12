namespace WebSalesSystem.Shared.Domain.FeatureFilters;
[FilterAlias(nameof(ModuleFilter))]
public class ModuleFeatureFilter : IContextualFeatureFilter<FeatureFilterContext>
{
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext evaluationContext, FeatureFilterContext filterContext)
    {
        if (evaluationContext.Parameters is IConfiguration configuration)
        {
            ModuleFilter? modulesList = configuration.Get<ModuleFilter>();

            if (modulesList is not null)
            {
                return Task.FromResult(modulesList.Modules.Any(module => string.Equals(module, filterContext.Module, StringComparison.OrdinalIgnoreCase)));
            }
        }

        return Task.FromResult(false);
    }
}