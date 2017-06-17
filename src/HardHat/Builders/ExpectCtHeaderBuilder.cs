using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat.Builders
{
    internal static class ExpectCtHeaderBuilder
    {
        internal static string Build(ulong maxAge, string reportUri, bool enforce = false)
        {
            if (string.IsNullOrWhiteSpace(reportUri))
            {
                throw new ArgumentNullException(nameof(reportUri), "Report URI must have a value");
            }
            var builder = new StringBuilder($"max-age={maxAge}; report-uri=\"{reportUri}\"");
            if (enforce)
            {
                builder.Append("; enforce");
            }
            return builder.ToString();
        }
    }
}
