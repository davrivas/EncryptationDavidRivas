using System.IO;
using System.Security.Cryptography;

namespace EncryptationDavidRivas.BL.Services
{
    public interface IDecryptionService
    {
        string SymmetricDecryption(byte[] cipherText, byte[] Key, byte[] IV);    
        byte[] AsymmetricDecryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding);
    }

    public class DecryptionService : IDecryptionService
    {
        // Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
        public string SymmetricDecryption(byte[] cipherText, byte[] Key, byte[] IV)
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

        // Taken from https://www.c-sharpcorner.com/UploadFile/75a48f/rsa-algorithm-with-C-Sharp2/
        public byte[] AsymmetricDecryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] decryptedData;
            using (var RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKey);
                decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
            }
            return decryptedData;
        }
    }
}
