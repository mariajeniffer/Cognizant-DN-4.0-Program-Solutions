﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApiDemo.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var hasAuthHeader = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
            if (!hasAuthHeader)
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
            }
            else if (!token.ToString().Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
            }

            base.OnActionExecuting(context);
        }
    }
}
