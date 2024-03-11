using HieuVeBan.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Reflection;

namespace HieuVeBan.Filters
{
    public class ApiResponseWrapping : ActionFilterAttribute
    {
        private readonly ILogger<ApiResponseWrapping> _logger;

        public ApiResponseWrapping(ILogger<ApiResponseWrapping> logger)
        {
            _logger = logger;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is OkResult)
                context.Result = new OkObjectResult(ResponseSuccess<object>.GetInstance(new { }));
            else if (context.Result is ObjectResult objectResult
                && (!objectResult?.Value?.GetType().IsSubclassOf(typeof(ApiResponse)) ?? true))
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                object? preValue = objectResult.Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                // Handle to ProblemDetails
                if (objectResult.Value is ProblemDetails pd)
                {
                    _logger.LogInformation("ProblemDetails for {action}. Status {status}, detail {detail}",
                        context.ActionDescriptor.DisplayName, pd.Status, pd.Detail);

                    preValue = pd.Detail;
                }

                preValue ??= ((HttpStatusCode?)objectResult.StatusCode)?.ToString();

                objectResult.Value = objectResult.StatusCode switch
                {
                    >= 400 and < 500 => ResponseError<object>.GetInstance(preValue),
                    _ => WrapValueToSuccess(preValue)
                };
            }
            base.OnResultExecuting(context);
        }

        private object WrapValueToSuccess(object? value)
        {
            Type? valueType = value?.GetType();
            if (valueType is not null
                && valueType.IsGenericType
                && valueType.GetGenericTypeDefinition() == typeof(PagedList<>))
            {
                Type pagedResponseType = typeof(PagedResponse<>).MakeGenericType(valueType.GetGenericArguments()[0]);
                Type[] getInstanceParameterTypes = new Type[] { valueType };
                MethodInfo getInstanceMethod = pagedResponseType.GetMethod(nameof(PagedResponse<object>.GetInstance), getInstanceParameterTypes)!;

                return getInstanceMethod.Invoke(null, new object[] { value! })!;
            }
            else
                return ResponseSuccess<object>.GetInstance(value);
        }
    }
}