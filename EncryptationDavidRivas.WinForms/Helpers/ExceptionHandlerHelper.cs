using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EncryptationDavidRivas.WinForms.Helpers
{
    public static class ExceptionHandlerHelper
    {
        public static void ExceptionHandler(Exception ex)
        {
            Debug.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
