using HardHat.Builders;
using HardHat;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HardHat.Middlewares
{
    public class Hpkp
    {
        private readonly bool reportOnly;
        private readonly RequestDelegate _next;
        private readonly string _header;
        public Hpkp(RequestDelegate next, ulong maxAge, ICollection<PublicKeyPin> keys, bool includeSubDomains = false, string reportUri = "", bool reportOnly = false)
        {
            if(maxAge < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxAge));
            }
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            if (keys.Count < 2)
            {
                throw new ArgumentException(" The current specification requires including a second pin for a backup key which isn't yet used in production. This allows for changing the server's public key without breaking accessibility for clients that have already noted the pins. This is important for example when the former key gets compromised.", nameof(keys));
            }
            _header = HpKpHeaderBuilder.Build(maxAge, keys, includeSubDomains, reportUri);
            _next = next;
            this.reportOnly = reportOnly;
        }

        public Task Invoke(HttpContext context)
        {
            if(reportOnly)
            {
                context.Response.Headers[Constants.HpKpHeaderReportOnly] = _header;
            }
            else
            {
                context.Response.Headers[Constants.HpKpHeader] = _header;
            }
            
            return _next.Invoke(context);
        }
    }
}
