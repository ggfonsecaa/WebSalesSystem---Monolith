global using System.Globalization;
global using System.Linq.Expressions;
global using System.Net;
global using System.Reflection;

global using MediatR;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.FeatureManagement;

global using WebSalesSystem.Shared.Domain.Constants;
global using WebSalesSystem.Shared.Domain.Exceptions;
global using WebSalesSystem.Shared.Domain.Extensions;
global using WebSalesSystem.Shared.Domain.FeatureFilters;
global using WebSalesSystem.Shared.Domain.FeatureFilters.Models;
global using WebSalesSystem.Shared.Domain.Globalization;
global using WebSalesSystem.Shared.Domain.Globalization.Resources.Validations;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.SubTenantAggregate;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;