using HieuVeBan.Contracts.Services;
using HieuVeBan.Models.Options;
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
        services.AddScoped<IMethodService, MethodService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IAdministrativeGeographyService, AdministrativeGeographyService>();
        services.AddScoped<IUserObjectService, UserObjectService>();
        services.AddScoped<IMethodResultService, MethodResultService>();
        services.AddScoped<IUserInformationService, UserInformationService>();

        services.Configure<SecurityOptions>(configuration.GetSection(SecurityOptions.SectionKey));

        return services;
    }
}