using System;
using System.Windows.Forms;
using DevExpress.Skins;

namespace HFC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] DllFile = new string[] { "DevExpress.Office.v12.2.Core.dll", "DevExpress.BonusSkins.v12.2.dll" };
            for (int i = 0; i < DllFile.Length; i++)
            {
                if (System.IO.File.Exists(@DllFile[i].ToString()))
                {
                    SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
                    SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);
                }
            }      
            try
            {
               Application.Run(new frmintro());
                // Application.Run(new Forms.frmSignalRequest());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
    }
}
