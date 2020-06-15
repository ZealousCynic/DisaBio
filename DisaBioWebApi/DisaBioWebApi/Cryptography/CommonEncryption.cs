using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace DisaBioWebApi.Cryptography
{
    public class CommonEncryption : ISymmetricEncryption
    {
        SymmetricAlgorithm _alg;
        int keylength = 16;
        int ivlength = 16;

        public int KeyLength { get { return keylength; } set { keylength = value; } }
        public int IVLength { get { return ivlength; } set { ivlength = value; } }
        public SymmetricAlgorithm Alg { get { return _alg; } }

        public CommonEncryption() : this(null) { }
        public CommonEncryption(SymmetricAlgorithm alg)
        {

            if (alg is null)
                _alg = Aes.Create();
            else
                _alg = alg;

            Initialize();
        }

        /// <summary>
        /// Initializes the instance's SymmetricAlgorithm (AES) with default values. 
        /// </summary>
        public void Initialize()
        {
            byte[] temp;
            _alg.Mode = CipherMode.CBC;
            _alg.Padding = PaddingMode.PKCS7;

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                temp = new byte[KeyLength];
                rng.GetBytes(temp);
                _alg.Key = temp;
                temp = new byte[IVLength];
                rng.GetBytes(temp);
                _alg.IV = temp;
            }
        }

        /// <summary>
        /// Initializes the instance's SymmetricAlgorithm (AES) with the provided keylength and ivlength. 
        /// Padding and Mode are left at whatever value they had.
        /// </summary>
        public void Initialize(int keylength, int ivlength)
        {
            byte[] temp;

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                temp = new byte[KeyLength];
                rng.GetBytes(temp);
                _alg.Key = temp;
                temp = new byte[IVLength];
                rng.GetBytes(temp);
                _alg.IV = temp;
            }
        }

        void Initialize(byte[] key, byte[] iv)
        {
            _alg.Key = key;
            _alg.IV = iv;
        }

        /// <summary>
        /// Initializes the instance's SymmetricAlgorithm (AES) with the provided mode and padding. 
        /// Keylength and ivlength are left at whatever value they had.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        void Initialize(CipherMode mode, PaddingMode padding)
        {
            _alg.Mode = mode;
            _alg.Padding = padding;
        }

        /// <summary>
        /// Initializes the instance's SymmetricAlgorithm (AES) with the provided values.
        /// </summary>
        /// <param name="keylength"></param>
        /// <param name="ivlength"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        public void Initialize(int keylength, int ivlength, CipherMode mode, PaddingMode padding)
        {
            Initialize(keylength, ivlength);
            Initialize(mode, padding);
        }

        /// <summary>
        /// Initializes the instance's SymmetricAlgorithm (AES) with the provided values.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="keylength"></param>
        /// <param name="ivlength"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>
        public void Initialize(byte[] key, byte[] iv, int keylength, int ivlength, CipherMode mode, PaddingMode padding)
        {

            Initialize(keylength, ivlength);
            Initialize(key, iv);
            Initialize(mode, padding);
        }

        /// <summary>
        /// Initializes the instance's SymmetricAlgorithm (AES) with the provided values.
        /// Padding and Cipher modes are left at default values.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="keylength"></param>
        /// <param name="ivlength"></param>
        /// <param name="mode"></param>
        /// <param name="padding"></param>

        public void Initialize(byte[] key, byte[] iv, int keylength, int ivlength)
        {
            Initialize(keylength, ivlength);
            Initialize(key, iv);
        }

        /// <summary>
        /// Encrypts a byte array with the instance specific algorithm.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] msg)
        {

            //Wonder how this will break?
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, _alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(msg, 0, msg.Length);
                    cs.Close();
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Decrypts a byte array with the instance specific algorithm.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] msg)
        {
            byte[] toRet = new byte[msg.Length];
            //Wonder how this will break?
            using (MemoryStream ms = new MemoryStream(msg))
            {
                using (CryptoStream cs = new CryptoStream(ms, _alg.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(toRet, 0, msg.Length);
                    cs.Close();
                }
            }
            return toRet;
        }
    }
}
