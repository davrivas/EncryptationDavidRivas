using System.IO;
using System.Security.Cryptography;

namespace EncryptationDavidRivas.BL.Services
{
    /// <summary>
    /// Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
    /// </summary>
    public interface IDecryptionService
    {
        /// <summary>
        /// AES decryption
        /// </summary>
        /// <param name="cipherText">Bytes to decrypt</param>
        /// <param name="Key">AES key</param>
        /// <param name="IV">AES initialization vector</param>
        string SymmetricDecrypt(byte[] cipherText, byte[] Key, byte[] IV);
    }

    /// <summary>
    /// Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
    /// </summary>
    public class DecryptionService : IDecryptionService
    {
        /// <summary>
        /// AES decryption
        /// </summary>
        /// <param name="cipherText">Bytes to decrypt</param>
        /// <param name="Key">AES key</param>
        /// <param name="IV">AES initialization vector</param>
        /// <returns></returns>
        public string SymmetricDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (var aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (var ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (var reader = new StreamReader(cs))
                        {
                            plaintext = reader.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
