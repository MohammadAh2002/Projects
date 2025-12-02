using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ActionFilters
{
    public class ValidateIDActionFilter : IActionFilter
    {

        private readonly string _parameterName;

        public ValidateIDActionFilter(string parameterName = "ID")
        {
            _parameterName = parameterName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ActionArguments.TryGetValue(_parameterName, out object? idValue) || idValue == null)
            {
                context.Result = new BadRequestObjectResult($"Missing ID parameter in request.");
                return;
            }

            if (!long.TryParse(idValue.ToString(), out long numericId) || numericId <= 0)
            {
                context.Result = new BadRequestObjectResult($"ID Must be a Valid Number Greater than Zero.");
                return;
            }
        }


    }
}
