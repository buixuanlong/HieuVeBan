using System.Text;
using HieuVeBan.Abstraction.Interfaces;
using HieuVeBan.Configurations;
using HieuVeBan.Data;
using HieuVeBan.Helpers;
using HieuVeBan.Options;
using HieuVeBan.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HieuVeBan;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddAppAuthorization();
        services.AddAppAuthentication(configuration);

        services.AddSingleton(TimeProvider.System);
        services.AddScoped<IUserContext, UserContext>();
        services.AddJwtService(configuration);

        services.AddApplicationDbContext(configuration);

        return services;
    }

    private static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSecurityOption>(configuration.GetSection(JwtSecurityOption.SectionKey));
        services.AddScoped<ITokenService, TokenService>();
    }

    private static IServiceCollection AddAppAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                var issuer = configuration.GetValue<string>($"{JwtSecurityOption.SectionKey}:{nameof(JwtSecurityOption.ValidIssuer)}");
                var audience = configuration.GetValue<string>($"{JwtSecurityOption.SectionKey}:{nameof(JwtSecurityOption.ValidAudience)}");
                var secret = configuration.GetValue<string>($"{JwtSecurityOption.SectionKey}:{nameof(JwtSecurityOption.Secret)}");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = audience,

                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SigningCredentialsHelper.BuildSymmetricSecurityKey(secret!),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

        return services;
    }

    private static IServiceCollection AddAppAuthorization(this IServiceCollection services)
    {
        return services.AddAuthorization(options =>
        {
            options.AddPolicy(SecurityConstant.Policies.InternalPolicy, policy =>
           {
               policy.RequireAuthenticatedUser();
               policy.RequireClaim("scope", SecurityConstant.Scopes.Internal);
           });

            options.AddPolicy(SecurityConstant.Policies.ExternalPolicy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", SecurityConstant.Scopes.External);
            });
        });
    }

    private static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddDbContext<ApplicationDbContext>(builder =>
            builder
#if DEBUG
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging()
#endif
                .UseSqlServer(Configuration.GetConnectionString("Default")!,
                    sql => sql.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name)));

        return services;
    }
}