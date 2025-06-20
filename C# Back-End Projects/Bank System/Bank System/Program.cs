using Business_Logic_Layer;
using Helper_Layer;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/requests.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddSwaggerGen(c =>
{

    String xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

app.Lifetime.ApplicationStopping.Register(() =>
{

    Log.Information("Application is shutting down. Logging out users...");

    UserLogsBLL.Logout();

    Log.Information("Logging out users Done :).");

});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
