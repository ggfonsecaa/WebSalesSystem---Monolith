namespace WebSalesSystem.Shared.Domain.Globalization;
public class CultureProvider : IDisposable
{
    public void SetCultureInfo(CultureInfo culture) => Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = culture;

    public void Dispose() => GC.SuppressFinalize(this);
}