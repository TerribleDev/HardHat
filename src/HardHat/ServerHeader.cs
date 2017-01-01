using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardHat
{
    public class ServerHeader
    {
        private readonly string header;
        private readonly RequestDelegate _next;
        public ServerHeader(RequestDelegate next, string header)
        {
            _next = next;
            this.header = header;
        }
  

        public Task Invoke(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(header))
            {
                context.Response.Headers.Remove(Constants.ServerHeader);
            }
            else
            {
                context.Response.Headers[Constants.ServerHeader] = header;
            }
            return _next?.Invoke(context);
        }
    }
}
