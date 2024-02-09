global using System.Diagnostics;
global using System.Net;
global using System.Reflection;

global using Carter;

global using ErrorOr;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Infrastructure;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;

global using WebSalesSystem.Shared.API.Contracts;
global using WebSalesSystem.Shared.Application;
global using WebSalesSystem.Shared.Application.Extensions.Middleware.MultiTenancy;
global using WebSalesSystem.Shared.Domain;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Infraestructure;