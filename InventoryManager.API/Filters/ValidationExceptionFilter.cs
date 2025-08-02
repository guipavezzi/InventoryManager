using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

public class ValidationExceptionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value.Errors.Any())
                .SelectMany(x => x.Value.Errors)
                .Select(x => new ValidationFailure("", x.ErrorMessage))
                .ToList();

            throw new ValidationException(errors);
        }
    }
    public void OnActionExecuted(ActionExecutedContext context) { }
}