using System;
using Microsoft.AspNetCore.Http.Features;
using Serilog;

namespace NoreBaseApiChallenge.Domain.shared;

public static class LogEnricher
{
    /// <summary>
    /// Enriches the Http request log with additional data via the Diagnostic Context

    ///</summary>
    ///<param name ="diagnosticContext">
    /// The Serilog disgnostic context
    ///</param>

    public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
    {
        diagnosticContext.Set("ClientIP", httpContext.Connection.RemoteIpAddress.ToString());
        diagnosticContext.Set("UserAgent", httpContext.Request.Headers["User-Agent"].FirstOrDefault());
        diagnosticContext.Set("Resource", httpContext.GetMetricsCurrentResourceName());

    }

    private static string GetMetricsCurrentResourceName(this HttpContext httpContext)
    {
        if (httpContext == null)
        {
            throw new ArgumentNullException(nameof(httpContext));
        }

        Endpoint endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;

        return endpoint?.Metadata.GetMetadata<EndpointNameMetadata>()?.EndpointName;
    }
}
