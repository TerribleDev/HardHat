using System;
using System.Collections.Generic;
using System.Text;

namespace HardHat
{
    public class PublicKeyPin
    {
        internal readonly HpKpCrypto cryptoType;
        internal readonly string fingerprint;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fingerprint"> the Base64 encoded Subject Public Key Information (SPKI) fingerprint. It is possible to specify multiple pins for different public keys.</param>
        /// <param name="cryptoType"></param>
        public PublicKeyPin(string fingerprint, HpKpCrypto cryptoType)
        {
            if(string.IsNullOrWhiteSpace(fingerprint))
            {
                throw new ArgumentNullException(nameof(fingerprint));
            }
            this.fingerprint = fingerprint;
            this.cryptoType = cryptoType;
        }
    }

    public enum HpKpCrypto
    {
        sha256
    }
}
