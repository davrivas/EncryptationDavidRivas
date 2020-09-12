using System.IO;
using System.Security.Cryptography;

namespace EncryptationDavidRivas.BL.Services
{
    /// <summary>
    /// Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// AES symmetryc encryption
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="Key">AES key</param>
        /// <param name="IV">AES initialization vector</param>
        byte[] SymmetricEncrypt(string plainText, byte[] Key, byte[] IV);
        
    }

    /// <summary>
    /// Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
    /// </summary>
    public class EncryptionService: IEncryptionService
    {
        /// <summary>
        /// AES symmetryc encryption
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="Key">AES key</param>
        /// <param name="IV">AES initialization vector</param>
        /// <returns></returns>
        public byte[] SymmetricEncrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (var aes = new AesManaged())
            {
                // Create encryptor    
                var encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (var ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (var sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            //Encoding.UTF8.GetString(encrypted); to convert to string
            return encrypted;
        }
    }
}
