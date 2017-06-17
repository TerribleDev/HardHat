using HardHat.Builders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardHat.Middlewares
{
    public class ExpectCt
    {
        private readonly RequestDelegate _next;
        private readonly string headerValue;
        public ExpectCt(RequestDelegate next, ulong maxAge, string reportUri, bool enforce = false)
        {
            this._next = next;
            if(string.IsNullOrWhiteSpace(reportUri))
            {
                throw new ArgumentNullException(nameof(reportUri), "Report URI must have a value");
            }
            headerValue = ExpectCtHeaderBuilder.Build(maxAge, reportUri, enforce);
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ExpectCt] = headerValue;
            return _next?.Invoke(context);
        }
    }
}
