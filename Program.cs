using System;
using System.Windows.Forms;


namespace $safeprojectname$
{

    class Program
    {

        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(true);
            LoginPage logIn = new LoginPage();
            Application.EnableVisualStyles();
            Application.Run(logIn);

        }
        public void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
