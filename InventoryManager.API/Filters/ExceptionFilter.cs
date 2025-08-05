using System.Diagnostics;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is InventoryManagerException)
        {
            HandleProjectException(context);
        }
        else if (context.Exception is ValidationException validationException)
        {
            var response = new FluentValidationException
            {
                Errors = validationException.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList()
            };

            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
            return;
        }

    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ConflictException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Result = new ConflictObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
        if (context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
            context.Result = new NotFoundObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
    }
}