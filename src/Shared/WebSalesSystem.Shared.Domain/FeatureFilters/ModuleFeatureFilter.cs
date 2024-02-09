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
                return Task.FromResult(modulesList.Modules.Contains(filterContext.Module));
            }
        }

        return Task.FromResult(false);
    }
}