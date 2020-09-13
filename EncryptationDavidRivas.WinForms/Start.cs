using EncryptationDavidRivas.BL.Services;
using EncryptationDavidRivas.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EncryptationDavidRivas.WinForms
{
    public partial class Start : Form
    {
        private readonly IEncryptionDecryptionService _service;
        private readonly List<Control> _controls;

        public Start(IEncryptionDecryptionService service)
        {
            InitializeComponent();
            _service = service;
            _controls = new List<Control>() { txtUserName, txtPassword, btnEncrypt, txtAES, txtRSA };
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text,
                password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Type both fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToggleControls();

                var encryptDecrypt = _service.EncryptAndDecrypt(userName, password);
                txtAES.Text = encryptDecrypt.EncryptedUserName;
                txtRSA.Text = encryptDecrypt.EncryptedPassword;

                ToggleControls();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ExceptionHandlerHelper.ExceptionHandler(ex);
            }
        }

        private void ToggleControls()
        {
            _controls.ForEach(x => x.Enabled = !x.Enabled);
        }
    }
}
