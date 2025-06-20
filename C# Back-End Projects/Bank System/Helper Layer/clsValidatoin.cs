using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Helper_Layer
{
    public static class clsValidatoin
    {
        public static bool ValidateEmail(string emailAddress)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(emailAddress);
        }

        public static bool ValidateInteger(string Number)
        {
            string pattern = @"^[0-9]*$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            string pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class GenderCharValidation : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null && ((char)value == 'M' || (char)value == 'F'))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "Gender must be either 'M' or 'F'.");

        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RequireLoggedInUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (clsGlobal.CurrentUserID == -1)
            {
                context.Result = new UnauthorizedObjectResult("User is not logged in.");

                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
