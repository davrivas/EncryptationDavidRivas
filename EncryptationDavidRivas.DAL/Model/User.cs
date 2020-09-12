using System;

namespace EncryptationDavidRivas.BL.Model
{
    /// <summary>
    /// This class is the mapping to the data inside the application
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Generated Unique Identifier
        /// </summary>
        public Guid Id { get; internal set; }
        /// <summary>
        /// User username (this should be unique)
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}
