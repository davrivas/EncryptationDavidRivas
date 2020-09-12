using EncryptationDavidRivas.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
            // TODO: remove
            return new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    LastName = "Doe",
                    Name = "John",
                    UserName = Guid.NewGuid().ToString(),
                    Password = Guid.NewGuid().ToString()
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now.AddSeconds(5),
                    LastName = "Doe",
                    Name = "Jane",
                    UserName = Guid.NewGuid().ToString(),
                    Password = Guid.NewGuid().ToString()
                }
            };
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            // TODO: remove
            return new User
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastName = "Doe",
                Name = "John",
                UserName = username,
                Password = password
            };
        }

        public void Insert(User user)
        {
            // TODO: remove
            Console.WriteLine(user.Id);
        }
    }
}
