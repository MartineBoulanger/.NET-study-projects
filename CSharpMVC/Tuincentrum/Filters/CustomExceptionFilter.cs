using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuincentrum.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _environment;
        public CustomExceptionFilter(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public override void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment()) return;
            switch (context.Exception.GetType().Name)
            {
                case "InvalidOperationException":
                    context.Result = new ViewResult { ViewName = "DatabaseError" };
                    break;
                case "DivideByZeroException":
                    context.Result = new ViewResult { ViewName = "ArithmeticError" };
                    break;
            }
        }
    }
}
