using GoalHub_API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using NLog;
using Service.Extensions;
using Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Enables JSON Patch support using Newtonsoft.Json without replacing default JSON settings
NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
.Services.BuildServiceProvider()
.GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
.OfType<NewtonsoftJsonPatchInputFormatter>().First();

// Add services to the container.
builder.Services.AddControllers(config => {

    config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
    config.ReturnHttpNotAcceptable = true;

    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
    {
        Duration = 120
    });

    config.CacheProfiles.Add("60SecondsDuration", new CacheProfile
    {
        Duration = 60
    });

}).AddXmlDataContractSerializerFormatters();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.ConfigureCors();

// Configure Logging
LogManager.Setup().LoadConfigurationFromFile("nlog.config");
builder.Services.ConfigureLoggerService();

// Configure Database
builder.Services.ConfigureDatabase(builder.Configuration);

// Configure Repository and Service Managers
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureFileStorageService();

// Configure Action Filters
builder.Services.ConfigureCustomActionFilters();

// Disable the default automatic model validation so we can use custom validation filters
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.FileStorageSettings(builder.Configuration);
builder.Services.ConfigureVersioning();
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimiting();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();

builder.Services.ConfigureDataShaper();

builder.Services.AddAuthentication();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureHealthChecks(builder.Configuration);
builder.Services.ConfigureSwagger();



// -------------------------------------------------------------

WebApplication app = builder.Build();

app.ConfigureExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    //app.UseExceptionHandler("/error");
//}

app.UseHsts();
app.UseHttpsRedirection();
app.ConfigureHealthChecksEndpoints();

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "GoalHub API v1");
    s.SwaggerEndpoint("/swagger/v2/swagger.json", "GoalHub API v2");
});

string storagePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\Repository\Storage"));
// Optional: create the folder if missing
if (!Directory.Exists(storagePath))
    Directory.CreateDirectory(storagePath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(storagePath),
    RequestPath = "/storage"
});



app.UseRateLimiter();

app.UseCors("CorsPolicy");

app.UseResponseCaching();
app.UseHttpCacheHeaders();

app.MapControllers();

app.Run();

public partial class Program { }