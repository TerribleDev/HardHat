using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardHat.Middlewares
{
    public class ReferrerPolicyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ReferrerPolicy policy;
        public ReferrerPolicyMiddleware(RequestDelegate next, ReferrerPolicy policy)
        {
            this.policy = policy;
            _next = next;
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ReferrerPolicy] = this.policy.Policy;
            return _next?.Invoke(context);
        }
    }
}
