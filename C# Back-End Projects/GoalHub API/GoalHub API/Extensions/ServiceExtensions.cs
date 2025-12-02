using Contracts;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices;
using Contracts.Repositories.IRepositories;
using Controllers.ActionFilters;
using Entities.ConfigurationModels;
using Entities.Models;
using HealthChecks.UI.Client;
using LoggerService.LoggerManager;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Base;
using Repository.Context;
using Service.DataShaping;
using System.Reflection;
using System.Text;
using System.Threading.RateLimiting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            /*

               • Instead of the AllowAnyOrigin() method which allows requests from any 
                 source, we can use the WithOrigins("https://example.com") which will 
                 allow requests only from that concrete source.

               • Also, instead of AllowAnyMethod() that allows all HTTP methods, we can use 
                 WithMethods("POST", "GET") that will allow only specific HTTP methods. 

               • Furthermore, you can make the same changes for the AllowAnyHeader() 
                 method by using, for example, the WithHeaders("accept", "content
                 type") method to allow only specific headers.

           */

            services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy", builder => builder
                                                            .AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                            .AllowAnyHeader()
                                                            .WithExposedHeaders("X-Pagination"));

            });
        }


        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            string dbType = configuration["Database:Type"] ?? "SqlServer";

            if (dbType.Equals("SqlServer", StringComparison.OrdinalIgnoreCase))
            {
                services.AddDbContext<GoalHubSQLContext>(opts =>
                       opts.UseSqlServer(configuration.GetConnectionString("SQLDBConnection")));

                services.AddScoped<IRepositoryManager, RepositoryManager<GoalHubSQLContext>>();

                services.ConfigureIdentity<GoalHubSQLContext>();
            }
            else
            {
                services.AddDbContext<GoalHubSQLiteContext>(opts =>
                       opts.UseSqlite(configuration.GetConnectionString("SQLiteDBConnection")));

                services.AddScoped<IRepositoryManager, RepositoryManager<GoalHubSQLiteContext>>();

                services.ConfigureIdentity<GoalHubSQLiteContext>();
            }

            return services;
        }

        public static void ConfigureServiceManager(this IServiceCollection services) =>
                          services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureFileStorageService(this IServiceCollection services) =>
                  services.AddScoped<IFileStorageService, FileStorageService>();

        public static void ConfigureCustomActionFilters(this IServiceCollection Services)
        {

            Services.AddScoped<ValidateIDActionFilter>();
            Services.AddScoped<ValidateNotNullIActionFilter>();
            Services.AddScoped<ValidateModelActionFilter>();
        }

        public static void FileStorageSettings(this IServiceCollection services, IConfiguration configuration)
        {
            StaticFilePaths FileStorageSettings = new StaticFilePaths();
            configuration.GetSection("StaticFilePaths").Bind(FileStorageSettings);

            services.AddSingleton(FileStorageSettings);
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");

            });
        }

        public static void ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(opt =>
            {
                opt.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                    RateLimitPartition.GetFixedWindowLimiter("GlobalLimiter",
                    partition => new FixedWindowRateLimiterOptions
                    {
                        AutoReplenishment = true,
                        PermitLimit = 5,
                        QueueLimit = 2,
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                        Window = TimeSpan.FromMinutes(1)
                    }));

                opt.AddPolicy("GetByIDPolicy", context =>
                RateLimitPartition.GetFixedWindowLimiter("SpecificLimiter",
                partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = 3,
                    Window = TimeSpan.FromSeconds(10)
                }));

                opt.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;

                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out TimeSpan retryAfter))
                        await context.HttpContext.Response
                            .WriteAsync($"Too many requests. " +
                            $"Please try again after {retryAfter.TotalSeconds} second(s).", token);
                    else
                        await context.HttpContext.Response
                            .WriteAsync("Too many requests. Please try again later.", token);
                };

            });
        }

        public static void ConfigureResponseCaching(this IServiceCollection services) =>
                                services.AddResponseCaching();

        public static void ConfigureHttpCacheHeaders(this IServiceCollection services) =>
                                services.AddHttpCacheHeaders((expirationOpt) =>
                                {
                                    expirationOpt.MaxAge = 65;
                                    expirationOpt.CacheLocation = CacheLocation.Private;
                                },
                                (validationOpt) =>
                                {
                                    validationOpt.MustRevalidate = true;
                                });

        public static void ConfigureDataShaper(this IServiceCollection Services)
        {

            Services.AddScoped(typeof(IDataShaper<>), typeof(DataShaper<>));
            Services.AddScoped<IDataShaperFactory, DataShaperFactory>();

        }

        public static void ConfigureIdentity<TContext>(this IServiceCollection services)
             where TContext : DbContext
        {
            IdentityBuilder builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<TContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            IConfiguration jwtSettings = configuration.GetSection("JwtSettings");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SECRET"]))
                };
            });
        }

        public static void ConfigureHealthChecks(this IServiceCollection Services, IConfiguration configuration)
        {

            Services.AddHealthChecks()
                    .AddSqlServer(configuration.GetConnectionString("SQLDBConnection")!, name: "Sql Health", tags: ["Database"])
                    .AddCheck<CustomHealthCheck>("CustomHealthCheck", tags: ["Custom"]);

            Services.AddHealthChecksUI()
                        .AddInMemoryStorage();
        }
        public static void ConfigureHealthChecksEndpoints(this WebApplication App)
        {

            App.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            App.MapHealthChecks("/health/custom", new HealthCheckOptions
            {
                Predicate = reg => reg.Tags.Contains("custom"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            App.MapHealthChecksUI();

        }

        public static void ConfigureSwagger(this IServiceCollection Services)
        {
            Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo {
                    
                    Title = "GoalHub API",
                    Version = "v1",
                    Description = "GoalHub API by Mohammad Ahmad",

                    Contact = new OpenApiContact
                    {
                        Name = "Mohammad Ahmad",
                        Email = "Lexmohammad2002@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/mohammadah2002/"),
                    },

                });

                s.SwaggerDoc("v2", new OpenApiInfo {
                    Title = "GoalHub API",
                    Version = "v2",
                    Description = "GoalHub API by Mohammad Ahmad",

                    Contact = new OpenApiContact
                    {
                        Name = "Mohammad Ahmad",
                        Email = "Lexmohammad2002@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/mohammadah2002/"),
                    },

                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                        },
                        new List<string>()
                    }
                });

            });

        }

    }                                                         

}
