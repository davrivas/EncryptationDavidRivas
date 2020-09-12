using System;

namespace EncryptationDavidRivas.DAL.ViewModel
{
    /// <summary>
    /// This class is the mapping to the data model in the Data Access Layer
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// User Generated Unique Identifier
        /// </summary>
        public Guid Id { get; set; }
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

        /// <summary>
        /// Initializes the mapping to the data model in the Data Access Layer
        /// </summary>
        public UserViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
