using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Options;
using HieuVeBan.Services.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HieuVeBan.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IAppUserService, AppUserService>();

        services.Configure<SecurityOptions>(configuration.GetSection(SecurityOptions.SectionKey));

        return services;
    }
}