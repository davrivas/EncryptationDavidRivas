using System;

namespace EncryptationDavidRivas.BL.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserModel()
        {
        }

        public UserModel(string userName, string name, string lastName, string password)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Name = name;
            LastName = lastName;
            Password = password;
        }
    }
}
