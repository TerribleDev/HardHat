using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat
{
    public static class CSPConstants
    {
        internal static string NonceHyphen = "nonce-";
        internal static string sha256 = "sha256-";
        internal static string sha384 = "sha384-";
        internal static string sha512 = "sha512-";

        /// <summary>
        /// Refers to the origin from which the protected document is being served, including the same URL scheme and port number. You must include the single quotes. Some browsers specifically exclude blob and filesystem from source directives. Sites needing to allow these content types can specify them using the Data attribute. This can be found at Sources.Scheme.*
        /// </summary>
        public const string Self = @"'self'";
        /// <summary>
        /// Allows the use of inline resources, such as inline <script> elements, javascript: URLs, inline event handlers, and inline <style> elements. You must include the single quotes.
        /// </summary>
        public const string UnsafeInline = "'unsafe-inline'";
        /// <summary>
        /// Allows the use of eval() and similar methods for creating code from strings. You must include the single quotes.
        /// </summary>
        public const string UnsafeEval = "'unsafe-eval'";
        /// <summary>
        /// Refers to the empty set; that is, no URLs match. The single quotes are required.
        /// </summary>
        public const string None = @"'none'";
        /// <summary>
        /// The strict-dynamic source expression specifies that the trust explicitly given to a script present in the markup, by accompanying it with a nonce or a hash, shall be propagated to all the scripts loaded by that root script. At the same time, any whitelist or source expressions such as 'self' or 'unsafe-inline' will be ignored.
        /// </summary>
        public const string StrictDynamic = "'strict-dynamic'";
        /// <summary>
        /// A whitelist for specific inline scripts using a cryptographic nonce (number used once). The server must generate a unique nonce value each time it transmits a policy. It is critical to provide an unguessable nonce, as bypassing a resource’s policy is otherwise trivial. See unsafe inline script for an example.
        /// </summary>
        /// <param name="base64Value"></param>
        /// <returns></returns>
        public static string Nonce(string base64Value) => CSPConstants.NonceHyphen + base64Value;
        /// <summary>
        /// A sha256, of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha256(string hash) => CSPConstants.sha256 + hash;
        /// <summary>
        /// A sha384 of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha384(string hash) => CSPConstants.sha384 + hash;
        /// <summary>
        /// A sha512 of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha512(string hash) => CSPConstants.sha512 + hash;

        public static class Schemes
        {
            /// <summary>
            /// Allows data: URIs to be used as a content source. This is insecure; an attacker can also inject arbitrary data: URIs. Use this sparingly and definitely not for scripts.
            /// </summary>
            public const string Data = "data:";
            /// <summary>
            /// Allows mediastream: URIs to be used as a content source.
            /// </summary>
            public const string MediaStream = "mediastream:";
            /// <summary>
            /// Allows blob: URIs to be used as a content source.
            /// </summary>
            public const string Blob = "blob:";
            /// <summary>
            /// Allows filesystem: URIs to be used as a content source.
            /// </summary>
            public const string filesystem = "filesystem:";

            public const string Http = "http:";

            public const string Https = "https:";

        }

    }


}
