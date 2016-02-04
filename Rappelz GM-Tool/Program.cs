using System;
using System.Windows.Forms;

namespace GM_Tool_V5 {
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault( false );
                Application.Run( new frmGlobalUI() );
            }
            catch (Exception ex){
                MessageBox.Show( ex.Message + "\r\nIf this happened at startup, go to C:\\Users\\YOUR_USER\\AppData\\Local\\Xijezu and delete EVERYTHING.\r\nTry to move the tool to a different folder if you don't want to.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
