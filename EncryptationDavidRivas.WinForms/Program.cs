using EncryptationDavidRivas.BL.Bootstrap;
using SimpleInjector;
using System;
using System.Windows.Forms;

namespace EncryptationDavidRivas.WinForms
{
    static class Program
    {
        public static Container Container { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Boostrap(); // inject dependencies
            Application.Run(Container.GetInstance<Start>());
        }

        // Taken from https://simpleinjector.readthedocs.io/en/latest/windowsformsintegration.html
        static void Boostrap()
        {
            // Create the container as usual.
            Container = new Container();

            // Register types
            Container.Register<Start>(Lifestyle.Singleton);
            Bootstrapper.Bootstrapp(Container);

            // Verify the container.
            Container.Verify();
        }
    }
}
