using HardHat;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat.Builders
{
    internal static class HpKpHeaderBuilder
    {
        internal static string Build(ulong maxAge, ICollection<PublicKeyPin> keys, bool includeSubDomains = false, string reportUri = "")
        {
            if (maxAge < 1)
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
            var builder = new StringBuilder();
            foreach(var key in keys)
            {
                // pin-sha256="base64==";
                builder.Append($"pin-{Enum.GetName(typeof(HpKpCrypto), key.cryptoType)}=\"{key.fingerprint}\"; ");
            }
            builder.Append($"max-age={maxAge}");
            if(includeSubDomains)
            {
                builder.Append($"; includeSubDomains");
            }
            if(!string.IsNullOrWhiteSpace(reportUri))
            {
                builder.Append($"; report-uri=\"{reportUri}\"");
            }
            return builder.ToString();
        }
    }
}
