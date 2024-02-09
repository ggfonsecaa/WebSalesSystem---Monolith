global using System.Linq.Expressions;
global using System.Net;
global using System.Reflection;

global using MediatR;

global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.FeatureManagement;

global using WebSalesSystem.Shared.Domain.Constants;
global using WebSalesSystem.Shared.Domain.Exceptions;
global using WebSalesSystem.Shared.Domain.FeatureFilters;
global using WebSalesSystem.Shared.Domain.FeatureFilters.Models;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy;