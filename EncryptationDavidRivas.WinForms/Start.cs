using EncryptationDavidRivas.BL.Model;
using EncryptationDavidRivas.BL.Services;
using System.Linq;
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

            var user = _userService.GetByUserNameAndPassword("davr", "2112");

            _userService.NewUser = new UserModel("davr", "David", "Rivas", "2112");
            _userService.Insert();

            var users = _userService.GetAll().ToList();
        }
    }
}
