using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using NoreBaseApiChallenge.Application.Dto;
using Serilog;

namespace NoreBaseApiChallenge.Extension;

public static class GlobalExceptionHandler
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    Log.Error("Something went wrong {Error}", contextFeature.Error);

                    Log.Error(contextFeature.Error, contextFeature.Error.StackTrace);
                    var err = new GenericResponse<object>
                    {
                        StatusCode = 500,
                        Message = "An error occurred, our team is looking into it"
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(err));
                }
            });
        });
    }
}
