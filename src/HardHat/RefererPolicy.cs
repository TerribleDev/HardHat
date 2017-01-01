using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace HardHat
{
    public class ReferrerPolicy
    {
        internal readonly string Policy;
        internal ReferrerPolicy(string policy)
        {
            this.Policy = policy;
        }
        /// <summary>
        /// The empty string "" corresponds to no referrer policy, causing a fallback to a referrer policy defined elsewhere, or in the case where no such higher-level policy is available, defaulting to "no-referrer-when-downgrade". This defaulting happens in the §8.3 Determine request’s Referrer algorithm.
        /// </summary>
        public static readonly ReferrerPolicy Empty = new ReferrerPolicy(string.Empty);
        /// <summary>
        /// The simplest policy is "no-referrer", which specifies that no referrer information is to be sent along with requests made from a particular request client to any origin. The header will be omitted entirely.
        /// </summary>
        public static readonly ReferrerPolicy NoReferrer = new ReferrerPolicy(Constants.Referrers.NoReferrer);
        /// <summary>
        /// The "no-referrer-when-downgrade" policy sends a full URL along with requests from a TLS-protected environment settings object to a potentially trustworthy URL, and requests from clients which are not TLS-protected to any origin.
        ///Requests from TLS-protected clients to non- potentially trustworthy URLs, on the other hand, will contain no referrer information.A Referer HTTP header will not be sent.
        /// </summary>
        public static readonly ReferrerPolicy NoReferrerWhenDowngrade = new ReferrerPolicy(Constants.Referrers.NoReferrerWhenDowngrade);
        /// <summary>
        /// The "same-origin" policy specifies that a full URL, stripped for use as a referrer, is sent as referrer information when making same-origin requests from a particular client.
        ///Cross-origin requests, on the other hand, will contain no referrer information.A Referer HTTP header will not be sent.
        /// </summary>
        public static readonly ReferrerPolicy SameOrigin = new ReferrerPolicy(Constants.Referrers.SameOrigin);
        /// <summary>
        /// The "origin" policy specifies that only the ASCII serialization of the origin of the request client is sent as referrer information when making both same-origin requests and cross-origin requests from a particular client.
        /// </summary>
        public static readonly ReferrerPolicy Origin = new ReferrerPolicy(Constants.Referrers.Origin);
        /// <summary>
        /// The "strict-origin" policy sends the ASCII serialization of the origin of the request client when making requests:
        /// <para/> 
        ///from a TLS-protected environment settings object to a potentially trustworthy URL, and from non-TLS-protected environment settings objects to any origin.
        ///Requests from TLS-protected request clients to non- potentially trustworthy URLs, on the other hand, will contain no referrer information.A Referer HTTP header will not be sent.
        /// </summary>
        public static readonly ReferrerPolicy StrictOrigin = new ReferrerPolicy(Constants.Referrers.StrictOrigin);
        /// <summary>
        /// The "origin-when-cross-origin" policy specifies that a full URL, stripped for use as a referrer, is sent as referrer information when making same-origin requests from a particular request client, and only the ASCII serialization of the origin of the request client is sent as referrer information when making cross-origin requests from a particular client.
        /// </summary>
        public static readonly ReferrerPolicy OriginWhenCrossOrigin = new ReferrerPolicy(Constants.Referrers.OriginWhenCrossOrigin);
        /// <summary>
        /// The "strict-origin-when-cross-origin" policy specifies that a full URL, stripped for use as a referrer, is sent as referrer information when making same-origin requests from a particular request client, and only the ASCII serialization of the origin of the request client when making cross-origin requests: 
        /// <para />
        /// from a TLS-protected environment settings object to a potentially trustworthy URL, and from non-TLS-protected environment settings objects to any origin.
        /// </summary>
        public static readonly ReferrerPolicy StrictOriginWhenCrossOrigin = new ReferrerPolicy(Constants.Referrers.StrictOriginWhenCrossOrigin);
        /// <summary>
        /// The "unsafe-url" policy specifies that a full URL, stripped for use as a referrer, is sent along with both cross-origin requests and same-origin requests made from a particular client.
        /// </summary>
        public static readonly ReferrerPolicy UnsafeUrl = new ReferrerPolicy(Constants.Referrers.UnsafeUrl);
    }
}
