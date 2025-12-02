using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Controllers.ActionFilters
{
    public class ValidateModelActionFilter : IActionFilter
    {

        public ValidateModelActionFilter()
        { 
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.ModelState.AddModelError("General", "The request contains invalid or missing data.");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}

