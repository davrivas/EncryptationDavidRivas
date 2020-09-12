using EncryptationDavidRivas.BL.Model;
using EncryptationDavidRivas.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EncryptationDavidRivas.BL.Services
{
    public interface IUserService
    {
        UserModel NewUser { get; set; }
        void Insert();
        IEnumerable<UserModel> GetAll();
        DecryptionModel GetByUserNameAndPassword(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IEncryptionService _encryptionService;
        private readonly IDecryptionService _decryptionService;
        private readonly IUserRepository _userRepository;

        public UserModel NewUser { get; set; }

        public UserService(IEncryptionService encryptionService,
            IDecryptionService decryptionService,
            IUserRepository userRepository)
        {
            _encryptionService = encryptionService;
            _decryptionService = decryptionService;
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll().Select(u => new UserModel
            {
                Id = u.Id,
                Name = u.Name,
                LastName = u.LastName,
                UserName = u.UserName,
                Password = u.Password,
                CreatedDate = u.CreatedDate
            });
        }

        public DecryptionModel GetByUserNameAndPassword(string username, string password)
        {
            var returnValue = new DecryptionModel();

            string encryptedUserNameString = string.Empty,
                encryptedPasswordString = string.Empty;

            // AES
            using (var aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encryptedUserName = _encryptionService.SymmetricEncryption(username, aes.Key, aes.IV);
                // Print encrypted string    
                encryptedUserNameString = Encoding.UTF8.GetString(encryptedUserName);
                // Decrypt the bytes to a string.    
                returnValue.DecriptedUserName = _decryptionService.SymmetricDecrypt(encryptedUserName, aes.Key, aes.IV);

                if (username != returnValue.DecriptedUserName)
                    throw new Exception("There was a problem encrypting the user name");
            }

            // RSA
            using (var RSA = new RSACryptoServiceProvider())
            {
                var ByteConverter = new UnicodeEncoding();
                byte[] plaintext;
                byte[] encryptedtext;

                // encrypt
                plaintext = ByteConverter.GetBytes(password);
                encryptedtext = _encryptionService.AsymmetricEncryption(plaintext, RSA.ExportParameters(false), false);
                encryptedPasswordString = ByteConverter.GetString(encryptedtext);

                // decrypt
                byte[] decryptedText = _decryptionService.AsymmetricDecryption(encryptedtext, RSA.ExportParameters(true), false);
                returnValue.DecriptedPassword = ByteConverter.GetString(decryptedText);

                if (password != returnValue.DecriptedPassword)
                    throw new Exception("There was a problem encrypting the password");
            }

            var userFromDb = _userRepository.GetByUserNameAndPassword(encryptedUserNameString, encryptedPasswordString);

            if (userFromDb == null)
                throw new Exception($"User '{username}' does not exists");

            returnValue.User = new UserModel
            {
                Id = userFromDb.Id,
                Name = userFromDb.Name,
                LastName = userFromDb.LastName,
                UserName = userFromDb.UserName,
                Password = userFromDb.Password,
                CreatedDate = userFromDb.CreatedDate
            };

            return returnValue;
        }

        public void Insert()
        {
            string encryptedUserName = string.Empty,
                encryptedPassword = string.Empty;

            // AES
            using (var aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encrypted = _encryptionService.SymmetricEncryption(NewUser.UserName, aes.Key, aes.IV);
                // Get encrypted string    
                encryptedUserName = Encoding.UTF8.GetString(encrypted);
                // Decrypt the bytes to a string.    
                string decryptedUserName = _decryptionService.SymmetricDecrypt(encrypted, aes.Key, aes.IV);

                // Check original and decrypted text
                if (NewUser.UserName != decryptedUserName)
                    throw new Exception("There was a problem encrypting the user name");
            }

            // RSA
            using (var RSA = new RSACryptoServiceProvider())
            {
                var ByteConverter = new UnicodeEncoding();
                
                // encrypt
                byte[] plaintext = ByteConverter.GetBytes(NewUser.Password);
                byte[] encryptedtext = _encryptionService.AsymmetricEncryption(plaintext, RSA.ExportParameters(false), false);
                encryptedPassword = ByteConverter.GetString(encryptedtext);

                // decrypt
                byte[] decrypted = _decryptionService.AsymmetricDecryption(encryptedtext, RSA.ExportParameters(true), false);
                string decryptedPassword = ByteConverter.GetString(decrypted);

                if (NewUser.Password != decryptedPassword)
                    throw new Exception("There was a problem encrypting the password");
            }

            NewUser.UserName = encryptedUserName;
            NewUser.Password = encryptedPassword;

            var userParameter = new User
            {
                Id = NewUser.Id,
                UserName = NewUser.UserName,
                Name = NewUser.Name,
                LastName = NewUser.LastName,
                Password = NewUser.Password,
                CreatedDate = DateTime.Now
            };
            _userRepository.Insert(userParameter);
            NewUser = null;
        }
    }
}
