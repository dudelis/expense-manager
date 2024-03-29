﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpenseManager.Web.Core.ActionFilters
{
    public class ValidateModelActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            var controller = context.Controller as ControllerBase;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
