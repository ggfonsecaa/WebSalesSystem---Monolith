using Carter;

using Microsoft.EntityFrameworkCore;
using WebSalesSystem.Shared.Application.Extensions.Middleware.MultiTenancy;
using WebSalesSystem.Shared.Infraestructure.Tenancy.ResolutionStrategy;
using WebSalesSystem.Shared.Infraestructure.Tenancy.Storage;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddMultiTenancy().WithResolutionStrategy<UrlResolutionStrategy>().WithStore<SqlStorage<DbContext>>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseMultiTenancy();

app.UseHttpsRedirection();

app.MapCarter();

app.Run();