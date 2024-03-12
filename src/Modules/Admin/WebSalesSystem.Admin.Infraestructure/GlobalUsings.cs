global using System.Reflection;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using WebSalesSystem.Admin.Infraestructure.Data;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;
global using WebSalesSystem.Shared.Infraestructure.Interceptors;