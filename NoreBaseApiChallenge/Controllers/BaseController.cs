using System;
using Microsoft.AspNetCore.Mvc;

namespace NoreBaseApiChallenge.Controllers;

public class BaseController : ControllerBase
{
    internal static int GetStatusCode(int statusCode)
    {
        return statusCode switch
        {
            200 => StatusCodes.Status200OK,
            201 => StatusCodes.Status201Created,
            404 => StatusCodes.Status404NotFound,
            500 => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status400BadRequest
        };
    }
}
