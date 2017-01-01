using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HardHat
{
    public class NoSniff
    {
        private readonly RequestDelegate _next;
        public NoSniff(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.XContentTypeOptions] = Constants.NoSniff;
            return _next.Invoke(context);
        }
    }
}
