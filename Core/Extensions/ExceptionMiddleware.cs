using Core.Utilities.Results;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
	public class ExceptionMiddleware
	{
		private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }


        private Task HandleExceptionAsync(HttpContext httpContext,Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal server error";
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
				httpContext.Response.StatusCode = 400;
				errors = ((ValidationException)e).Errors;
                return httpContext.Response.WriteAsync(new ValidationFailureErrors
				{
                    Message = message,
                    StatusCode = httpContext.Response.StatusCode,
                    Errors = errors
                }.ToString());
			}
            return httpContext.Response.WriteAsync(new ErrorDetail
            {
                Message = message,
                StatusCode = httpContext.Response.StatusCode,
                
            }.ToString());
        }

	}
}
