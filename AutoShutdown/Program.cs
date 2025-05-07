using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace AutoShutdown
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutoShutdown());

            string exePath = @"C:\Users\artem\source\repos\AutoShutdown\AutoShutdown\bin\Debug\AutoShutdown.exe"; 
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AutoShutdown.lnk"; 

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = exePath;
            shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(exePath);
            shortcut.Save();

        }
    }


}
