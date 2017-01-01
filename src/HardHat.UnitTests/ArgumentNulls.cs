using HardHat.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace HardHat.UnitTests
{
    public class ArgumentNulls
    {
        [Fact]
        public void ArgumentNullsTests()
        {
            Assert.Throws<ArgumentNullException>(() => new FrameGuard(null, null));
            Assert.Throws<ArgumentNullException>(() => new ReferrerPolicyMiddleware(null, null));
            Assert.Throws<ArgumentNullException>(() => new FrameGuardOptions(string.Empty));
        }
    }
}
