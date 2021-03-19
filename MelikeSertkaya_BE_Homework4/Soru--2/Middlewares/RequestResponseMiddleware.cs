using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru__2.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestResponseMiddleware> logger;

        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //Request
            var originalBodyStream = httpContext.Response.Body;
            logger.LogInformation($"Query Keys:{ httpContext.Request.QueryString}");

            MemoryStream requestBody = new MemoryStream();
            await httpContext.Request.Body.CopyToAsync(requestBody);
            requestBody.Seek(0, SeekOrigin.Begin);
            string requestText = await new StreamReader(requestBody).ReadToEndAsync();
            requestBody.Seek(0, SeekOrigin.Begin);

            var tempStream = new MemoryStream();
            httpContext.Response.Body = tempStream;

            await next.Invoke(httpContext); //Response burada oluşuyor
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            string responseText = await new StreamReader(tempStream, Encoding.UTF8).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            await httpContext.Response.Body.CopyToAsync(originalBodyStream);

            logger.LogInformation($"Request:{requestText}");
            logger.LogInformation($"Response:{responseText}");
        }
    }
}
