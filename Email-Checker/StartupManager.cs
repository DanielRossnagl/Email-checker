using System;
using System.IO;
using IWshRuntimeLibrary;

namespace Email_Checker
{
    public static class StartupManager
    {
        /* Attempts to create a shortcut leading to the executable file,
            * which will then be placed into the startup folder,
            * enabling the application to start automatically upon system boot.
            */
        public static void AddToStartup()
        {
            
            try
            {
      
                string executablePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Email-Checker.exe");

  
                string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

       
                string startupShortcutPath = Path.Combine(startupFolderPath, "Email-Checker.lnk");

  
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(startupShortcutPath);
                shortcut.TargetPath = executablePath;
                shortcut.Save();

                Console.WriteLine("Die Verknüpfung wurde erfolgreich im Startup-Ordner erstellt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}
