using HieuVeBan.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Configurations
{
    public static class ApiBehaviorConfiguration
    {
        public static IMvcBuilder InvalidModelStateOption(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.ConfigureApiBehaviorOptions(otps =>
            {
                otps.SuppressInferBindingSourcesForParameters = true;
                otps.InvalidModelStateResponseFactory = context =>
                {
                    var msg = context.ModelState.Where(x => x.Value!.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                        .Select(x => $"{string.Join(',', context.ModelState[x.Key]?.Errors.Select(e => e.ErrorMessage)!)}");

                    var res = ResponseError<object>.GetInstance(
                        errorCode: ApiResponseCode.ApiBehaviorError,
                        error: msg);

                    return new BadRequestObjectResult(res);
                };
            });
        }
    }
}
