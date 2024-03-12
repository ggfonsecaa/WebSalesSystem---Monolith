using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

using Newtonsoft.Json;

namespace WebSalesSystem.Shared.API.Filters.RequestEventsFilters;
public abstract class OnInitFilter<T> : IActionFilter
{
    public virtual void OnActionExecuting(ActionExecutingContext context)
    {
        StringValues requestData = context.HttpContext.Request.Form["Data"];
        Request<T>? request = JsonConvert.DeserializeObject<Request<T>>(requestData);
        // Do something before the action executes.
    }

    public virtual void OnActionExecuted(ActionExecutedContext context)
    {
        // Do something after the action executes.
    }
}