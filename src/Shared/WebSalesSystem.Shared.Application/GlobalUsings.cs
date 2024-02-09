global using System.Reflection;

global using ErrorOr;

global using FluentValidation;
global using FluentValidation.Results;

global using MediatR;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using WebSalesSystem.Shared.Application.Behaviors;
global using WebSalesSystem.Shared.Application.Extensions.Middleware.MultiTenancy;
global using WebSalesSystem.Shared.Domain.Middleware;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy;
global using WebSalesSystem.Shared.Infraestructure.Data;
global using WebSalesSystem.Shared.Infraestructure.Tenancy;
global using WebSalesSystem.Shared.Infraestructure.Tenancy.ResolutionStrategy;
global using WebSalesSystem.Shared.Infraestructure.Tenancy.Storage;