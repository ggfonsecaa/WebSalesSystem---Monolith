global using System.Reflection;

global using AutoMapper;

global using ErrorOr;

global using FluentValidation;

global using MediatR;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.FeatureManagement;

global using WebSalesSystem.Admin.Application.Models;
global using WebSalesSystem.Admin.Infraestructure.Data;
global using WebSalesSystem.Shared.Domain.Globalization.Resources.Validations;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;