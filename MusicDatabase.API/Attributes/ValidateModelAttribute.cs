using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicDatabase.API
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string errorMessage = "";
                context.ModelState.Keys
                 .SelectMany(key => context.ModelState[key].Errors.Select(x => x.ErrorMessage))
                 .ToList()
                 .ForEach(error => errorMessage += error + "\n");
                context.Result = new BadRequestObjectResult(new BaseAPIResponse()
                {
                    IsSuccess = false,
                    Message = errorMessage
                });
            }
        }
    }
}
