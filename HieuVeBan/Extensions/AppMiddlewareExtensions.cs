using HieuVeBan.Middlewares;

namespace HieuVeBan.Extension
{
    public static class AppMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder applicationBuilder)
        => applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}
