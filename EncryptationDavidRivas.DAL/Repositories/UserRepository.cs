using EncryptationDavidRivas.BL.Model;
using System;
using System.Collections.Generic;

namespace EncryptationDavidRivas.DAL.Repositories
{
    public interface IUserRepository
    {
        void Insert(User user);
        IEnumerable<User> GetAll();
        User GetByUserNameAndPassword(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Insert(User user)
        {
            throw new NotImplementedException();
        }
    }
}
