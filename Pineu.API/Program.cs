using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Pineu.API.Configuration;
using Pineu.API.Configurations;
using Pineu.Application.Behaviors;
using Pineu.Persistence.Context;
using Scrutor;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureDbContexts();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT();
builder.Services.ConfigureSwagger();
builder.Services.ConfigurePolicies();
builder.Services.AddCORS();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureLogging();
builder.Services.ConfigureRateLimiter();

builder.Services.Scan(
    selector => selector
        .FromAssemblies(
            Pineu.Infrastructure.AssemblyReference.Assembly,
            Pineu.Persistence.AssemblyReference.Assembly)
        .AddClasses(c =>
            c.NotInNamespaces("Pineu.Persistence.Specifications")
        )
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

builder.Services.AddMediatR(cfg => cfg
    .RegisterServicesFromAssemblyContaining(typeof(Pineu.Application.AssemblyReference)));

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.AddValidatorsFromAssembly(Pineu.Application.AssemblyReference.Assembly);
//ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("fa");

builder.Services
    .AddControllers(options => {
        options.Conventions.Add(new ApiVersionPrefixConvention());
        options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    })
    .AddApplicationPart(Pineu.Persistence.AssemblyReference.Assembly)
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<Role>>();

    await applicationDbContext.Database.MigrateAsync();
    await ApplicationDbContext.SeedAdminDefaultPermissionsAsync(roleManager);
}

string uploads = Path.Combine(builder.Environment.ContentRootPath, "uploads/");

if (!Directory.Exists(uploads)) {
    Directory.CreateDirectory(uploads);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddUseStaticFiles();
//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.AddMiddlewares();
app.MapControllers();
app.UseRateLimiter();

app.Run();
