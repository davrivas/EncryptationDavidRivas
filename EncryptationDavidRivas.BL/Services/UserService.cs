using EncryptationDavidRivas.DAL.ViewModel;
using System;
using System.Collections.Generic;

namespace EncryptationDavidRivas.BL.Services
{
    public interface IUserService
    {
        void Insert();
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetByUserNameAndPassword(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IEncryptionService _encryptionService;
        private readonly IDecryptionService _decryptionService;

        public UserService(IEncryptionService encryptionService,
            IDecryptionService decryptionService)
        {
            _encryptionService = encryptionService;
            _decryptionService = decryptionService;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetByUserNameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }
}
