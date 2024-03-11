using EntityFramework.Exceptions.Common;
using HieuVeBan.Abstraction.Exceptions;
using HieuVeBan.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mime;
using System.Text.Json;

namespace HieuVeBan.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger _logger;

        private readonly JsonSerializerOptions _serializeOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public GlobalExceptionMiddleware(
            IWebHostEnvironment webHostEnvironment,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        => exception switch
        {
            NotFoundException ex => HandleNotFoundExceptionAsync(context, ex),
            ValidationException ex => HandleValidationExceptionAsync(context, ex),
            PermissionDeniedException ex => HandlePermissionDeniedExceptionAsync(context, ex),
            AppException ex => HandleAppExceptionAsync(context, ex),
            DbUpdateException ex => HandleDbUpdateExceptionAsync(context, ex),
            TaskCanceledException ex => HandleTaskCanceledExceptionAsync(context, ex),

            _ => HandleUnhandledException(context, exception)
        };

        private Task HandleTaskCanceledExceptionAsync(HttpContext context, TaskCanceledException exception)
        {
            _logger.LogWarning(exception, exception.Message);

            var res = ResponseError<string>.GetInstance(ApiResponseCode.OtherError, "Request is canceled");

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonSerializer.Serialize(res, _serializeOptions));
        }

        private Task HandleAppExceptionAsync(HttpContext context, AppException exception)
        {
            _logger.LogInformation(exception, exception.Message);

            var res = ResponseError<string>.GetInstance(ApiResponseCode.OtherError, exception.Message);

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonSerializer.Serialize(res, _serializeOptions));
        }

        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            _logger.LogTrace(exception, "{msg}\n{errors}", exception.Message, JsonSerializer.Serialize(exception.PropertiesError, _serializeOptions));

            var errors = exception.PropertiesError
                .GroupBy(x => x.Key)
                .Select(g => new
                {
                    PropertyName = g.Key,
                    Messages = g.Select(x => x.Value)
                });

            var res = ResponseError<object>.GetInstance(ApiResponseCode.TypeErrorValidation, errors);

            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonSerializer.Serialize(res, _serializeOptions));
        }

        private Task HandleUnhandledException(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            var res = ResponseError<string>.GetInstance(ApiResponseCode.UnhandledError,
                _webHostEnvironment.IsDevelopment()
                    ? exception.Message
                    : "An unexpected error occurred");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonSerializer.Serialize(res, _serializeOptions));
        }

        private Task HandleDbUpdateExceptionAsync(HttpContext context, DbUpdateException dbUpdateException)
        {
            _logger.LogWarning(dbUpdateException, dbUpdateException.Message);

            var res = dbUpdateException switch
            {
                UniqueConstraintException ex => ResponseError<string>.GetInstance(ApiResponseCode.DbUniqueConstraint,
                        _webHostEnvironment.IsDevelopment()
                            ? $"{ex.Message}. {ex.InnerException?.Message}"
                            : "The provided data already exists."),

                CannotInsertNullException ex => ResponseError<string>.GetInstance(ApiResponseCode.DbCannotInsertNull,
                        _webHostEnvironment.IsDevelopment()
                            ? $"{ex.Message}. {ex.InnerException?.Message}"
                            : "A value is missing and cannot be added."),

                MaxLengthExceededException ex => ResponseError<string>.GetInstance(ApiResponseCode.DbMaxLengthExceeded,
                        _webHostEnvironment.IsDevelopment()
                            ? $"{ex.Message}. {ex.InnerException?.Message}"
                            : "A value exceeds the allowed limit."),

                NumericOverflowException ex => ResponseError<string>.GetInstance(ApiResponseCode.DbNumericOverflow,
                        _webHostEnvironment.IsDevelopment()
                            ? $"{ex.Message}. {ex.InnerException?.Message}"
                            : "A number exceeds the allowed limit."),

                ReferenceConstraintException ex => ResponseError<string>.GetInstance(ApiResponseCode.DbReferenceConstrain,
                        _webHostEnvironment.IsDevelopment()
                        ? $"{ex.Message}. {ex.InnerException?.Message}"
                        : "An error occurred due to a reference constraint violation. Maybe the data is being used or the reference is incorrect."),

                _ => ResponseError<string>.GetInstance(ApiResponseCode.DbUnhandledError,
                        _webHostEnvironment.IsDevelopment()
                            ? dbUpdateException.Message
                            : "An unexpected error occurred while saving data.")
            };

            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonSerializer.Serialize(res, _serializeOptions));
        }

        private Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException exception)
        {
            if (exception.Value is null)
                _logger.LogInformation(exception, exception.Message);
            else
                _logger.LogInformation(exception, "{msg}. Param: {param}", exception.Message, exception.Value);

            var res = ResponseError<string>.GetInstance(ApiResponseCode.NotFound, exception.Message);
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            return context.Response.WriteAsync(JsonSerializer.Serialize(res, _serializeOptions));
        }

        private Task HandlePermissionDeniedExceptionAsync(HttpContext context, PermissionDeniedException exception)
        {
            _logger.LogInformation(exception, exception.Message);
            context.Response.StatusCode = StatusCodes.Status403Forbidden;

            return Task.CompletedTask;
        }
    }
}
