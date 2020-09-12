using EncryptationDavidRivas.BL.Services;
using System.Windows.Forms;

namespace EncryptationDavidRivas.WinForms
{
    public partial class Start : Form
    {
        private readonly IUserService _userService;

        public Start(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            _userService.GetByUserNameAndPassword("davr", "2112");
        }

        //private void AES()
        //{
        //    try
        //    {
        //        string raw = Guid.NewGuid().ToString();
        //        // Create Aes that generates a new key and initialization vector (IV).    
        //        // Same key must be used in encryption and decryption    
        
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show(exp.Message);
        //    }
        //}
    }
}
