global using System.ComponentModel.DataAnnotations;
global using System.Net;
global using System.Reflection;

global using AutoMapper;

global using Carter;

global using ErrorOr;

global using MediatR;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ModelBinding;
global using Microsoft.AspNetCore.Routing;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using WebSalesSystem.Admin.API.Contracts;
global using WebSalesSystem.Admin.Application;
global using WebSalesSystem.Admin.Application.Commands.RegisterTenant;
global using WebSalesSystem.Admin.Application.Models;
global using WebSalesSystem.Admin.Domain;
global using WebSalesSystem.Admin.Domain.Globalization.Resources.Validations;
global using WebSalesSystem.Admin.Infraestructure;
global using WebSalesSystem.Shared.API.Contracts;
global using WebSalesSystem.Shared.API.Helpers;
global using WebSalesSystem.Shared.Domain.SeedWork;
global using WebSalesSystem.Shared.Domain.Tenancy.Aggregates.TenantAggregate;