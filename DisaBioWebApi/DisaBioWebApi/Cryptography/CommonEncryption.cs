using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DisaBioWebApi.Cryptography
{
    public class CommonEncryption : ISymmetricEncryption
    {
        SymmetricAlgorithm alg;

        public CommonEncryption(SymmetricAlgorithm algorithm) { alg = algorithm; }

        public byte[] Encrypt(byte[] toEncrypt)
        {
            // Do magic

            return new byte[1];
        }

        public byte[] Decrypt(byte[] toDecrypt)
        {
            // Undo magic

            return new byte[1];
        }
    }
}
