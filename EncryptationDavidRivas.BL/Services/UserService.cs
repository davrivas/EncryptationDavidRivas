using EncryptationDavidRivas.BL.ViewModel;
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
        UserViewModel User { get; set; }

        void Insert();
        IEnumerable<UserViewModel> GetAll();
        DecryptionViewModel GetByUserNameAndPassword(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IEncryptionService _encryptionService;
        private readonly IDecryptionService _decryptionService;
        private readonly IUserRepository _userRepository;

        public UserViewModel User { get; set; }

        public UserService(IEncryptionService encryptionService,
            IDecryptionService decryptionService,
            IUserRepository userRepository)
        {
            _encryptionService = encryptionService;
            _decryptionService = decryptionService;
            _userRepository = userRepository;
            User = new UserViewModel();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                LastName = u.LastName,
                UserName = u.UserName,
                Password = u.Password
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DecryptionViewModel GetByUserNameAndPassword(string username, string password)
        {
            var returnValue = new DecryptionViewModel();

            string encryptedUserNameString = string.Empty,
                encryptedPasswordString = string.Empty;

            // AES
            using (var aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encryptedUserName = _encryptionService.SymmetricEncrypt(username, aes.Key, aes.IV);
                // Print encrypted string    
                encryptedUserNameString = Encoding.UTF8.GetString(encryptedUserName);
                // Decrypt the bytes to a string.    
                returnValue.DecriptedUserName = _decryptionService.SymmetricDecrypt(encryptedUserName, aes.Key, aes.IV);
            }

            // RSA

            var userFromDb = _userRepository.GetByUserNameAndPassword(encryptedUserNameString, encryptedPasswordString);

            if (userFromDb == null)
                throw new NullReferenceException("User does not exists");

            returnValue.User = new UserViewModel
            {
                Id = userFromDb.Id,
                Name = userFromDb.Name,
                LastName = userFromDb.LastName,
                UserName = userFromDb.UserName,
                Password = userFromDb.Password
            };

            return returnValue;
        }

        public void Insert()
        {
            // AES
            using (var aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encrypted = _encryptionService.SymmetricEncrypt(User.UserName, aes.Key, aes.IV);
                // Get encrypted string    
                string encryptedString = Encoding.UTF8.GetString(encrypted);
                // Decrypt the bytes to a string.    
                //string decrypted = _decryptionService.SymmetricDecrypt(encrypted, aes.Key, aes.IV);
            }

            // RSA

            // restart User
            User = new UserViewModel();
        }
    }
}
