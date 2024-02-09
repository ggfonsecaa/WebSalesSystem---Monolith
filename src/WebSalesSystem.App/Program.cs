using WebSalesSystem.Shared.Domain.FeatureFilters;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.Services.ConfigureHttpJsonOptions(options => {
//    options.SerializerOptions.WriteIndented = true;
//    options.SerializerOptions.IncludeFields = true;
//});

//builder.Services.AddModule<SharedModule>(builder.Configuration)
//                .AddModule<AdminModule>(builder.Configuration);

builder.Services.AddModulesFrom(builder.Configuration, [SharedApiReference.Assembly, AdminApiReference.Assembly]);

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();
builder.Services.AddFeatureManagement().AddFeatureFilter<ModuleFeatureFilter>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddMemoryCache();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.ConfigureServicesFrom([SharedApiReference.Assembly, AdminApiReference.Assembly]);

app.MapCarter();

app.UseHttpsRedirection();

app.Run();