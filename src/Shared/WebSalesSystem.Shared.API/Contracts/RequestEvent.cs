namespace WebSalesSystem.Shared.API.Contracts;
public class RequestEvent(int id, string name) : Enumeration(id, name)
{
    public static readonly RequestEvent OnInit = new(1, nameof(OnInit));
    public static readonly RequestEvent OnLoad = new(2, nameof(OnLoad));
    public static readonly RequestEvent OnChange = new(3, nameof(OnChange));
    public static readonly RequestEvent OnCreate = new(4, nameof(OnCreate));
    public static readonly RequestEvent OnRead = new(5, nameof(OnRead));
    public static readonly RequestEvent OnUpdate = new(6, nameof(OnUpdate));
    public static readonly RequestEvent OnDelete = new(7, nameof(OnDelete));
    public static readonly RequestEvent OnDestroy = new(8, nameof(OnDestroy));
}