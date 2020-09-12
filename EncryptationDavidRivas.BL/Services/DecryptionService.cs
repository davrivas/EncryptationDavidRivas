using System.IO;
using System.Security.Cryptography;

namespace EncryptationDavidRivas.BL.Services
{
    /// <summary>
    /// Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
    /// </summary>
    public interface IDecryptionService
    {
        string Decrypt(byte[] cipherText, byte[] Key, byte[] IV);
    }

    /// <summary>
    /// Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
    /// </summary>
    public class DecryptionService : IDecryptionService
    {
        public string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
