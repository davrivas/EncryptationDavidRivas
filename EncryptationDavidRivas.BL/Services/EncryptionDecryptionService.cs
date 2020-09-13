using EncryptationDavidRivas.BL.Model;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EncryptationDavidRivas.BL.Services
{
    public interface IEncryptionDecryptionService
    {
        EncryptionDecryptionModel EncryptAndDecrypt(string username, string password);
    }

    public class EncryptionDecryptionService : IEncryptionDecryptionService
    {
        private readonly IEncryptionService _encryptionService;
        private readonly IDecryptionService _decryptionService;

        public EncryptionDecryptionService(IEncryptionService encryptionService,
            IDecryptionService decryptionService)
        {
            _encryptionService = encryptionService;
            _decryptionService = decryptionService;
        }

        public EncryptionDecryptionModel EncryptAndDecrypt(string username, string password)
        {
            var returnValue = new EncryptionDecryptionModel();

            // AES
            using (var aes = new AesManaged())
            {
                // encrypt
                byte[] encryptedUserName = _encryptionService.SymmetricEncryption(username, aes.Key, aes.IV);
                returnValue.EncryptedUserName = Encoding.UTF8.GetString(encryptedUserName);

                // decrypt
                string decriptedUserName = _decryptionService.SymmetricDecryption(encryptedUserName, aes.Key, aes.IV);

                // check decryption
                if (username != decriptedUserName)
                    throw new Exception("There was a problem encrypting the user name");
            }

            // RSA
            using (var RSA = new RSACryptoServiceProvider())
            {
                var ByteConverter = new UnicodeEncoding();

                // encrypt
                byte[] plaintext = ByteConverter.GetBytes(password);
                byte[] encryptedtext = _encryptionService.AsymmetricEncryption(plaintext, RSA.ExportParameters(false), false);
                returnValue.EncryptedPassword = ByteConverter.GetString(encryptedtext);

                // decrypt
                byte[] decryptedText = _decryptionService.AsymmetricDecryption(encryptedtext, RSA.ExportParameters(true), false);
                var decriptedPassword = ByteConverter.GetString(decryptedText);

                // check decryption
                if (password != decriptedPassword)
                    throw new Exception("There was a problem encrypting the password");
            }

            return returnValue;
        }
    }
}
