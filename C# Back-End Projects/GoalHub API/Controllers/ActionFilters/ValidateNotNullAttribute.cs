using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ActionFilters
{
    public class ValidateNotNullIActionFilter: IActionFilter
    {
        public ValidateNotNullIActionFilter()
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            object? model = context.ActionArguments.Values.FirstOrDefault(value => value != null &&
                                         !value.GetType().IsPrimitive &&
                                         value.GetType() != typeof(string));

            if (model == null)
            {
                context.Result = new BadRequestObjectResult("Request Body Cannot be null.");
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
