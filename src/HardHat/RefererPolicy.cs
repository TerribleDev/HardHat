using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HardHat
{
    public class ReferrerPolicyMiddlewear
    {
        private readonly RequestDelegate _next;
        private readonly ReferrerPolicy policy;
        public ReferrerPolicyMiddlewear(RequestDelegate next, ReferrerPolicy policy)
        {
            this.policy = policy;
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[Constants.ReferrerPolicy] = this.policy.Policy;
            return _next.Invoke(context);
        }
    }
    public struct ReferrerPolicy
    {
        internal readonly string Policy;
        internal ReferrerPolicy(string policy)
        {
            this.Policy = policy;
        }
        //todo: document https://www.w3.org/TR/referrer-policy/#referrer-policies

        public static readonly ReferrerPolicy Empty = new ReferrerPolicy(string.Empty);
        public static readonly ReferrerPolicy NoReferrer = new ReferrerPolicy(Constants.Referrers.NoReferrer);
        public static readonly ReferrerPolicy NoReferrerWhenDowngrade = new ReferrerPolicy(Constants.Referrers.NoReferrerWhenDowngrade);
        public static readonly ReferrerPolicy SameOrigin = new ReferrerPolicy(Constants.Referrers.SameOrigin);
        public static readonly ReferrerPolicy Origin = new ReferrerPolicy(Constants.Referrers.Origin);
        public static readonly ReferrerPolicy StrictOrigin = new ReferrerPolicy(Constants.Referrers.StrictOrigin);
        public static readonly ReferrerPolicy OriginWhenCrossOrigin = new ReferrerPolicy(Constants.Referrers.OriginWhenCrossOrigin);
        public static readonly ReferrerPolicy StrictOriginWhenCrossOrigin = new ReferrerPolicy(Constants.Referrers.StrictOriginWhenCrossOrigin);
        public static readonly ReferrerPolicy UnsafeUrl = new ReferrerPolicy(Constants.Referrers.UnsafeUrl);
    }
}
