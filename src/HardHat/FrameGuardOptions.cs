using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardHat
{
    public struct FrameGuardOptions
    {
        internal readonly string domain;
        internal readonly FrameGuard? guard;
        /// <summary>
        /// Set frameguard to same origin or deny
        /// </summary>
        /// <param name="guard"></param>
        public FrameGuardOptions(FrameGuard guard)
        {
            this.guard = guard;
            domain = string.Empty;
        }
        /// <summary>
        /// allow iFrames from a certain domain (only one)
        /// </summary>
        /// <param name="domain"></param>
        public FrameGuardOptions(string domain)
        {
            guard = null;
            if (string.IsNullOrWhiteSpace(domain))
            {
                throw new ArgumentNullException(nameof(domain));
            }
            this.domain = domain;
        }


        public enum FrameGuard
        {
            SAMEORIGIN,
            DENY
        }
    }

}
