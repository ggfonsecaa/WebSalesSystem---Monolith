namespace WebSalesSystem.Shared.Infraestructure.Extensions;
public static class TypeExtension
{
    public static bool SkipTenantValidation(this Type type)
    {
        List<bool>? entities = [typeof(ICommonEntity).IsAssignableFrom(type)];

        return entities.Aggregate((b1, b2) => b1 || b1);
    }
}