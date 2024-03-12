global using System.Linq.Expressions;
global using System.Reflection;

global using HashidsNet;

global using MediatR;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;

global using WebSalesSystem.Shared.Domain.ConfigurationModels;
global using WebSalesSystem.Shared.Domain.Constants;
global using WebSalesSystem.Shared.Domain.Extensions;
global using WebSalesSystem.Shared.Domain.Middleware;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
global using WebSalesSystem.Shared.Infraestructure.Data;
global using WebSalesSystem.Shared.Infraestructure.Extensions;
global using WebSalesSystem.Shared.Infraestructure.Interceptors;
global using WebSalesSystem.Shared.Infraestructure.Repositories;
global using WebSalesSystem.Shared.Infraestructure.Tenancy;