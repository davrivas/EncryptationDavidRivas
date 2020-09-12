using EncryptationDavidRivas.DAL.Repositories;
using EncryptationDavidRivas.DAL.ViewModel;
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
        UserViewModel GetByUserNameAndPassword(string username, string password);
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

        public UserViewModel GetByUserNameAndPassword(string username, string password)
        {
            string decrypted;

            // AES
            using (var aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encrypted = _encryptionService.SymmetricEncrypt(username, aes.Key, aes.IV);
                // Print encrypted string    
                string encryptedString = Encoding.UTF8.GetString(encrypted);
                // Decrypt the bytes to a string.    
                decrypted = _decryptionService.SymmetricDecrypt(encrypted, aes.Key, aes.IV);
            }

            return null;
        }

        public void Insert()
        {


            // AES
            using (var aes = new AesManaged())
            {
                // Encrypt string    
                byte[] encrypted = _encryptionService.SymmetricEncrypt(User.UserName, aes.Key, aes.IV);
                // Print encrypted string    
                string encryptedString = Encoding.UTF8.GetString(encrypted);
                // Decrypt the bytes to a string.    
                string decrypted = _decryptionService.SymmetricDecrypt(encrypted, aes.Key, aes.IV);
            }
        }
    }
}
