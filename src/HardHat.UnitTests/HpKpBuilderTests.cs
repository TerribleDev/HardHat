using System;
using System.Collections.Generic;
using System.Text;
using HardHat.Builders;
using Xunit;

namespace HardHat.UnitTests
{
    public class HpKpBuilderTests
    {
        [Fact]
        public void ThrowsExceptions()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                HpKpHeaderBuilder.Build(0, null);
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                HpKpHeaderBuilder.Build(2, null);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                HpKpHeaderBuilder.Build(2, new List<PublicKeyPin>());
            });

            var results = HpKpHeaderBuilder.Build(2, new List<PublicKeyPin>()
            {
                new PublicKeyPin("yo", HpKpCrypto.sha256),
                new PublicKeyPin("dawg", HpKpCrypto.sha256)
            }, true, "/awesome");

            Assert.Equal<string>("pin-sha256=\"yo\"; pin-sha256=\"dawg\"; max-age=2; includeSubDomains; report-uri=\"/awesome\"", results);

        }
    }
}
