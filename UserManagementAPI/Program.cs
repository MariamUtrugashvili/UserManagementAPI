using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using UserManagement.Persistance.Context;
using UserManagementAPI.Infrastructure;
using UserManagementAPI.Infrastructure.Authentication;
using UserManagementAPI.Infrastructure.Extensions;
using UserManagementAPI.Infrastructure.Extensions.MiddleWare;
using UserManagementAPI.Infrastructure.Extensions.Swagger;

var builder = WebApplication.CreateBuilder(args);

#region Serilog
builder.Logging.ClearProviders();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddTokenAuthentication(builder.Configuration.GetSection(nameof(JWTConfiguration)).GetSection(nameof(JWTConfiguration.Secret)).Value!);

builder.ConfigureServices();

#region JWT
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection(nameof(ConnectionString)));
builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection(nameof(JWTConfiguration)));
#endregion

builder.Services.AddHttpContextAccessor();

#region AddDbContext
builder.Services.AddDbContext<UserManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionString.DefaultConnection))));

builder.Services.AddScoped<DbContext, UserManagementDbContext>();
#endregion

#region Authentication
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("User", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Role", "User", "Admin");

    });
    opts.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Role", "Admin");
    });
});
#endregion

#region FluentValidation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
#endregion

builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseGlobalExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region UseAuthorization
app.UseAuthentication();
app.UseAuthorization();
#endregion

app.MapControllers();

app.Run();
