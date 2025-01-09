using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pineu.API.Constants;
using Pineu.Persistence.Constants.Enums;
using Pineu.Persistence.Context;
using Serilog;
using Serilog.Sinks.MariaDB;
using Serilog.Sinks.MariaDB.Extensions;
using System.Text;
using System.Threading.RateLimiting;

namespace Pineu.API.Configuration {
    public static class ServiceExtensions {
        public static void ConfigureDbContexts(this IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>();
        }

        public static void ConfigureIdentity(this IServiceCollection services) {
            var builder = services.AddIdentityCore<User>(options => {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            }).AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder = new IdentityBuilder(builder.UserType, typeof(Role), services);
        }

        public static void ConfigureJWT(this IServiceCollection services) {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtConfigs.JwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfigs.JwtKey)),
                        SaveSigninToken = true,
                    };
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services) {
            services.AddSwaggerGen(option => {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "0auth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigurePolicies(this IServiceCollection services) {
            services.AddAuthorization(options => {
                foreach (var (permissionName, policiesList) in Role.DefaultPermissions)
                    DefinePolicy(options, permissionName, policiesList);
            });
        }

        //public static void AddCORS(this IServiceCollection services) {
        //    services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
        //        //builder.WithOrigins("http://localhost:5000");
        //        //"http://localhost:3000", "http://172.19.105.10:3000", "http://192.168.10.78", "http://192.168.10.78:3000", "http://192.168.10.78:3001", "http://192.168.60.83", "http://localhost:5006"
        //        builder.AllowAnyOrigin()
        //            .AllowAnyMethod()
        //            .AllowAnyHeader();
        //        //.AllowCredentials();
        //    }));
        //}

        public static void AddCORS(this IServiceCollection services) {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.WithOrigins(
                        "http://localhost:3000",
                        "http://172.19.105.10:3000",
                        "http://192.168.10.78",
                        "http://192.168.10.78:3000",
                        "http://192.168.10.78:3001",
                        "http://192.168.60.83",
                        "http://localhost:5006",
                        "https://pineu-app.liara.run"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials(); // Enable credentials
            }));
        }


        public static void ConfigureVersioning(this IServiceCollection services) {
            services.AddApiVersioning(option => {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        public static void ConfigureLogging(this IServiceCollection services) {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
            .WriteTo.MariaDB(
                    connectionString: DBSettings.ApplicationDbContextConnectionString,
                    tableName: "Logs",
                    autoCreateTable: true,
                    options: new MariaDBSinkOptions())
                .Enrich.FromLogContext()
                //.MinimumLevel.Error()
                .CreateLogger();
        }

        public static void ConfigureRateLimiter(this IServiceCollection services) {
            services.AddRateLimiter(rateLimiterOptions =>
            {
                rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
                {
                    options.PermitLimit = 60;
                    options.Window = TimeSpan.FromMinutes(1);
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 5;
                });
            });
        }


        public static void AddServices(this IServiceCollection services) {

        }

        private static void DefinePolicy(AuthorizationOptions options, PermissionNames resource,
            IEnumerable<Policies> actions) {
            foreach (var policyName in actions.Select(action => Role.MakePolicy(resource, action)))
                options.AddPolicy(policyName, policy => policy.RequireAuthenticatedUser().RequireClaim(policyName)
                );
        }
    }
}
