using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApiDemo.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            File.WriteAllText("exception_log.txt", context.Exception.ToString());

            context.Result = new ObjectResult("Something went wrong")
            {
                StatusCode = 500
            };
        }
    }
}
