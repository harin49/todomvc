
using Microsoft.AspNetCore.Http.Extensions;

namespace todo.Middlewares
{
    public class HttpRequestTrackerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"=============> There's a new Request!: {context.Request.GetDisplayUrl()}");
            Console.WriteLine($"=============> this is a https request: {context.Request.IsHttps}");
            await next(context);
        }
    }
}