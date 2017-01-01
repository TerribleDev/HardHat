using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HardHat.Middlewares
{
    public class IENoOpen
    {
        private readonly RequestDelegate _next;
        public IENoOpen(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.DowloadOptions] = Constants.NoOpen;
            return _next?.Invoke(context);
        }
    }
}
