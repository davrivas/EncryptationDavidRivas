using System.IO;
using System.Security.Cryptography;

namespace EncryptationDavidRivas.BL.Services
{
    public interface IEncryptionService
    {
        byte[] SymmetricEncryption(string plainText, byte[] Key, byte[] IV);
        byte[] AsymmetricEncryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding);
    }

    public class EncryptionService: IEncryptionService
    {
        // Taken from https://www.c-sharpcorner.com/article/aes-encryption-in-c-sharp/
        public byte[] SymmetricEncryption(string plainText, byte[] Key, byte[] IV)
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
            return encrypted;
        }

        // Taken from https://www.c-sharpcorner.com/UploadFile/75a48f/rsa-algorithm-with-C-Sharp2/
        public byte[] AsymmetricEncryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] encryptedData;
            using (var RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKey);
                encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
            }
            return encryptedData;
        }
    }
}
