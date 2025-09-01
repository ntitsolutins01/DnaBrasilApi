using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Constants;
using DnaBrasilApi.Infrastructure.Data;
using DnaBrasilApi.Infrastructure.Data.Interceptors;
using DnaBrasilApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DnaBrasilApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthorization(options =>{
            options.AddPolicy(Policies.Consultar, policy => 
                    policy.RequireRole(Roles.Administrador));
            options.AddPolicy(Policies.Incluir, policy => 
                    policy.RequireRole(Roles.Administrador));
            options.AddPolicy(Policies.Alterar, policy => 
                    policy.RequireRole(Roles.Administrador));
            options.AddPolicy(Policies.Excluir, policy => 
                    policy.RequireRole(Roles.Administrador));
            options.AddPolicy(Policies.Habilitar, policy => 
                    policy.RequireRole(Roles.Administrador));
            options.AddPolicy(Policies.Download, policy => 
                    policy.RequireRole(Roles.Administrador));
            options.AddPolicy(Policies.Upload, policy => 
                    policy.RequireRole(Roles.Administrador));
            });

        services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            //.AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }
}
