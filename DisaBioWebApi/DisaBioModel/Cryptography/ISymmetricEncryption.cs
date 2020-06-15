using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisaBioModel.Cryptography
{
    interface ISymmetricEncryption
    {
        byte[] Encrypt(byte[] toEncrypt);
        byte[] Decrypt(byte[] toDecrypt);
    }
}
