using Asp.Versioning;

namespace HieuVeBan.Configurations
{
    public static class ApiVersioningConfiguration
    {
        public static IServiceCollection ConfigApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(otps =>
            {
                otps.DefaultApiVersion = new ApiVersion(1, 0);
                otps.AssumeDefaultVersionWhenUnspecified = true;
                otps.ReportApiVersions = true;
                otps.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(otps =>
            {
                otps.GroupNameFormat = "'v'VVV";
                otps.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
