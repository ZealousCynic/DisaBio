using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DisaBioModel.Cryptography
{
    public class EncryptionInitializer
    {

        public CommonEncryption GetAlgorithm(string path)
        {
            string keyname = "key.txt";
            string ivname = "iv.txt";
            int keylength = 16;
            int ivlength = 16;
            byte[] key = null;
            byte[] iv = null;

            CommonEncryption toReturn = new CommonEncryption();

            key = GetBytes(path, keyname, keylength);
            iv = GetBytes(path, ivname, ivlength);


            toReturn.Initialize(key, iv, keylength, ivlength);

            return toReturn;
        }

        byte[] GetBytes(string path, string name, int length)
        {
            byte[] data;

            Directory.CreateDirectory(path);

            if (File.Exists(path + name))
                data = GetFromFile(path + name);
            else
            {
                data = GenerateKey(length);
                SaveBytes(path + name, data);
            }
            return data;
        }

        byte[] GetFromFile(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            return data;
        }

        byte[] GenerateKey(int length)
        {
            byte[] key = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }

            return key;
        }

        void SaveBytes(string path, byte[] key)
        {
            File.WriteAllBytes(path, key);
        }
    }
}
