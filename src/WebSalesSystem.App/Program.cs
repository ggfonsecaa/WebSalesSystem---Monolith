using WebSalesSystem.Shared.Infraestructure.Extensions.Middleware.Globalization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.WriteIndented = true;
    options.SerializerOptions.IncludeFields = true;
});

//builder.Services.AddModule<SharedModule>(builder.Configuration)
//                .AddModule<AdminModule>(builder.Configuration);

builder.Services.AddModulesFrom(builder.Configuration, [SharedApiReference.Assembly, AdminApiReference.Assembly]);
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(opts =>
{
    opts.GroupNameFormat = "'v'V";
    opts.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddFeatureManagement().AddFeatureFilter<ModuleFeatureFilter>();
builder.Services.AddMultiTenancy().WithResolutionStrategy<UrlResolutionStrategy>().WithStore<TenantStorage<AdminDbContext>>();
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseGlobalization();

app.UseExceptionHandler();

app.UseMultiTenancy();

app.ConfigureServicesFrom([SharedApiReference.Assembly, AdminApiReference.Assembly]);

app.MapCarter();

app.UseHttpsRedirection();

app.Run();