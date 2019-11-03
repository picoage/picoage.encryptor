using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Picoage.Encryptor
{
    public static class TextEncryptor
    {
        public static string EncryptPlainText(byte[] key, byte[] iv, string value)
        {
            if (key == null) throw new EncryptorExpection("Key cannot be null");

            if (iv == null) throw new EncryptorExpection("Initialization vector cannot be null");

            if (string.IsNullOrEmpty(value)) throw new EncryptorExpection("Value cannot be null or empty"); 
            
            byte[] plainTextInBytes = Encoding.UTF8.GetBytes(value);

            using (Aes algorithm = Aes.Create())
            {
                using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
                {
                    return Convert.ToBase64String(Crypt(plainTextInBytes, encryptor));
                }
            }
        }

        public static string DecryptChiperText(byte[] key, byte[] iv, string chiperText)
        {
            if (key == null) throw new EncryptorExpection("Key cannot be null");

            if (iv == null) throw new EncryptorExpection("Initialization vector cannot be null");

            if (string.IsNullOrEmpty(chiperText)) throw new EncryptorExpection("Chipertext cannot be null or empty");

            byte[] chiperTextInBytes = Convert.FromBase64String(chiperText);
            using (Aes algorithm = Aes.Create())
            {
                using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
                {
                    return Encoding.UTF8.GetString(Crypt(chiperTextInBytes, decryptor));
                }
            }
        }

        private static byte[] Crypt(byte[] data, ICryptoTransform cryptor)
        {
            MemoryStream memoryStream = new MemoryStream();

            using (Stream stream = new CryptoStream(memoryStream, cryptor, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }
            return memoryStream.ToArray();
        }
    }
}
