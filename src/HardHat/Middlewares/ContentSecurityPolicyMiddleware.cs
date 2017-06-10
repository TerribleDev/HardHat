using HardHat.Builders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardHat.Middlewares
{
    public class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _policy;
        public ContentSecurityPolicyMiddleware(RequestDelegate next, ContentSecurityPolicy policy)
        {
            if(policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }
            _policy = ContentSecurityHeaderBuilder.Build(policy);
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ContentSecurityPolicyHeader] = _policy;
            return _next?.Invoke(context);
        }
    }
}
