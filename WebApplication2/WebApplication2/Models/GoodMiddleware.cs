using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Repository;

namespace WebApplication2.Models
{
    public class GoodMiddleware
    {
        RequestDelegate next;

        public GoodMiddleware(RequestDelegate request)
        {
            next = request;
        }

        public async Task InvokeAsync(HttpContext context, IRepository<Good> sender)
        {
            context.Response.Headers["Content-type"] = "text/html; charset=utf-8";

            string ind = context.Request.Query["index"];

            await context.Response.WriteAsync("Hello");
        }
    }
}
