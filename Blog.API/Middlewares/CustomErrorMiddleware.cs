using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Business.CustomErrors;
using Core.ResponseModel;
using Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.API.Middlewares
{
    public class CustomErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await CustomErrorHandle(ex, context);
            }
        }

        private async Task CustomErrorHandle(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (ex.GetType() == typeof(ValidationException))
            {
                var response = new ApiResponse<object>();
                context.Response.StatusCode = 400;
                var errors = ((ValidationException)ex).Errors.Select(c => new ErrorDto() { ErrorMessage = c.ErrorMessage, PropertyName = c.PropertyName });
                response.IsSuccess = false;
                response.Errors = errors.ToList();

                var serialize = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(serialize);
            }

            if (ex.GetType() == typeof(ClientException))
            {
                var response = new ApiResponse<object>();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;

                var serialize = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(serialize);
            }

            if (ex.GetType() == typeof(Exception))
            {
                var serialize = JsonSerializer.Serialize(new { error = ex.Message });
                await context.Response.WriteAsync(serialize);
            }
        }
    }
}
